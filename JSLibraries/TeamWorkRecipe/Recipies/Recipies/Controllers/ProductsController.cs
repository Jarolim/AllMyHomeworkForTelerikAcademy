using Recipies.Data;
using Recipies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Recipies.Controllers
{
    public class ProductsController : BaseApiController
    {
        [ActionName("all")]
        public IQueryable<string> GetAll()
        {
            var context = new RecipesContext();

            var recipeEntities = context.Products;
            var model = recipeEntities.OrderBy(x => x.Title)
                .Select(x => x.Title).Distinct();

            return model;
        }

        [ActionName("measurements")]
        public IQueryable<string> GetAllMessuramentTypes()
        {
            List<string> measurements = new List<string>();
            foreach (var item in Enum.GetNames(typeof(Measurement)))
            {
                measurements.Add(item);
            }

            return measurements.AsQueryable();
        }

    }
}
