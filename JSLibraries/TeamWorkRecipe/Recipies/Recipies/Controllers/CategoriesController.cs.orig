using Recipies.Data;
using Recipies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Recipies.Controllers
{
    public class CategoriesController : BaseApiController
    {
        public IQueryable<CategoryModel> GetAll()
        {

            var context = new RecipesContext();

            var recipeEntities = context.Categories;
            var model = recipeEntities.OrderBy(x => x.Title)
                .Select(CategoryModel.FromCategoryToCategoryModel);

            return model;
        }

        [ActionName("recipes")]
        public IQueryable<RecipeModel> GetByCategory(int id)
        {

            var context = new RecipesContext();

            //this.CheckSession(context); //no need of authorized access

            var category = context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                throw new ArgumentException("Not found category with such id","id");
            }
         
           var recipeEntities = context.Categories.FirstOrDefault(c => c.Id == id).Recipes.AsQueryable();

            var models = recipeEntities.Select(RecipeModel.FromRecipeToRecipeModel);

            return models;
        }
    }
}
