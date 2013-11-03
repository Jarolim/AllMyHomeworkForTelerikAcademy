using Recipies.Data;
using Recipies.Model;
using Recipies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Recipies.Controllers
{
    public class RecipesController : BaseApiController
    {
        [HttpGet]
        [ActionName("all")]
        public HttpResponseMessage GetAll()
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
               {
                   var context = new RecipesContext();

                   var recipeEntities = context.Recipes;
                   var model = recipeEntities
                       .Select(RecipeModel.FromRecipeToRecipeModel);

                   if (model == null)
                   {
                       throw new ArgumentException("No recipes");
                   }

                   var response = this.Request.CreateResponse(HttpStatusCode.OK, model);
                   return response;
               });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("get")]
        public HttpResponseMessage GetById(int id)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                 {
                     var context = new RecipesContext();

                     // CheckSession(context);

                     var recipeEntities = context.Recipes.Include("Categories");
                     var model = recipeEntities.Where(x => x.Id == id)
                         .Select(RecipeDetails.FromRecipeToRecipeDetails)
                         .FirstOrDefault();


                     //var model =
                     //(from r in recipeEntities
                     // where r.Id == id
                     // select new RecipeDetails()
                     // {
                     //     Title = r.Title,
                     //     CreatorUser = r.Creator.Username,
                     //     CategoryName = r.Category.Title,
                     //     PublishDate = r.PublishDate,
                     //     Rating = r.Fans.AsQueryable().Count(),
                     //     Id = r.Id,
                     //     Content = r.Content,
                     //     Products = (from p in r.Products
                     //                 select new ProductDetails()
                     //                 {
                     //                     Name = p.Product.Title,
                     //                     Quantity = p.Quantity,
                     //                     Measurement = Enum.GetName(p.Mesaurement.GetType(), p.Mesaurement)
                     //                 }).AsQueryable()

                     // }).FirstOrDefault();

                     if (model == null)
                     {
                         throw new ArgumentException("No such recipe");
                     }

                     var response = this.Request.CreateResponse(HttpStatusCode.OK, model);
                     return response;
                 });

            return responseMsg;
        }

        [HttpPost]
        [ActionName("add")]
        public HttpResponseMessage Add(RecipeDetails recipe)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new RecipesContext();

                var user = GetCurrentUser(context);

                var category = context.Categories.FirstOrDefault(x => x.Title == recipe.CategoryName);

                if (category == null)
                {
                    throw new ArgumentException("No such category");
                }

                var addedRecipe = new Recipe()
                    {
                        Category = category,
                        Content = recipe.Content,
                        Creator = user,
                        PublishDate = DateTime.Now,
                        Title = recipe.Title
                    };

                foreach (var product in recipe.Products)
                {
                    var productToAdd = context.Products.FirstOrDefault(x => x.Title == product.Name);

                    if (productToAdd == null)
                    {
                        productToAdd = new Product { Title = product.Name };
                    }

                    addedRecipe.Products.Add(new Ingredient()
                    {
                        Product = productToAdd,
                        Quantity = product.Quantity,
                        Mesaurement = (Measurement)Enum.Parse(typeof(Measurement), product.Measurement)

                    });
                }

                context.Recipes.Add(addedRecipe);
                context.SaveChanges();

                var response = this.Request.CreateResponse(HttpStatusCode.Created, addedRecipe);
                return response;
            });

            return responseMsg;
        }

        [HttpPut]
        [ActionName("like")]
        public HttpResponseMessage Like(int id)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new RecipesContext();

                var user = GetCurrentUser(context);

                var recipe = context.Recipes.FirstOrDefault(x => x.Id == id);

                if (recipe == null)
                {
                    throw new ArgumentException("No such recipe.");
                }

                if (!user.Favorites.Contains(recipe))
                {
                    user.Favorites.Add(recipe);
                    context.SaveChanges();
                }
                var response = this.Request.CreateResponse(HttpStatusCode.NoContent);
                return response;
            });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("favourites")]
        public HttpResponseMessage Favourites()
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new RecipesContext();

                var user = GetCurrentUser(context);

                var favourites = from favourite
                                 in user.Favorites
                                 select new RecipeModel()
                                 {
                                     CategoryName = favourite.Category.Title,
                                     CreatorUser = favourite.Creator.Username,
                                     PublishDate = favourite.PublishDate,
                                     Rating = favourite.Fans.Count,
                                     Title = favourite.Title
                                 };
                var response = this.Request.CreateResponse(HttpStatusCode.OK, favourites);
                return response;
            });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("mine")]
        public HttpResponseMessage Mine()
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new RecipesContext();

                var user = GetCurrentUser(context);

                var favourites = from favourite
                                 in user.MyRecipes
                                 select new RecipeModel()
                                 {
                                     CategoryName = favourite.Category.Title,
                                     CreatorUser = favourite.Creator.Username,
                                     PublishDate = favourite.PublishDate,
                                     Rating = favourite.Fans.Count,
                                     Title = favourite.Title
                                 };
                var response = this.Request.CreateResponse(HttpStatusCode.OK, favourites);
                return response;
            });

            return responseMsg;
        }
        [HttpGet]
        [ActionName("state")]
        public HttpResponseMessage State(int id)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new RecipesContext();

                var sessionKey = this.Request.Headers.GetValues("X-sessionKey").FirstOrDefault();

                //sessionKey = sessionKey.Substring("sessionKey=".Length);
                if (sessionKey == null)
                {
                    throw new InvalidOperationException("No session key found.");
                }

                var user = context.Users.FirstOrDefault(
                    usr => usr.SessionKey == sessionKey);

                if (user == null)
                {
                    StateModel notLoggedUserState = new StateModel() { State = false };
                    var notLoggedUserResponse = this.Request.CreateResponse(HttpStatusCode.OK, notLoggedUserState);
                    return notLoggedUserResponse;
                }

                var recipe = context.Recipes.FirstOrDefault(x => x.Id == id);

                if (recipe == null)
                {
                    throw new ArgumentException("No such recipe");
                }

                StateModel state = new StateModel() { State = recipe.Fans.Contains(user) };

                var response = this.Request.CreateResponse(HttpStatusCode.OK, state);
                return response;
            });

            return responseMsg;
        }

        [HttpPut]
        [ActionName("delete")]
        public HttpResponseMessage Delete(int id)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new RecipesContext();

                var user = GetCurrentUser(context);

                var recipe = context.Recipes.FirstOrDefault(x => x.Id == id);

                if (recipe == null)
                {
                    throw new ArgumentException("No such recipe.");
                }

                if (recipe.Creator.UserId != user.UserId && user.Role != Role.Admin)
                {
                    throw new Exception("This user doesn't have the permissions to delete this recipe.");
                }

                context.Recipes.Remove(recipe);
                user.MyRecipes.Remove(recipe);

                context.SaveChanges();
                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                return response;
            });

            return responseMsg;
        }
    }
}
