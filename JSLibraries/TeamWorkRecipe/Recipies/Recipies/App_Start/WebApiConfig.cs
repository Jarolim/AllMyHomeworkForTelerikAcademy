using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Recipies
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.Routes.MapHttpRoute(
               name: "ProductsApiMeasurements",
               routeTemplate: "api/products/measurements",
               defaults: new
               {
                   controller = "products",
                   action = "measurements"
               }
           );

            config.Routes.MapHttpRoute(
                name: "ProductsApi",
                routeTemplate: "api/products",
                defaults: new
                {
                    controller = "products",
                    action = "all"
                }
            );

            config.Routes.MapHttpRoute(
                name: "RecipesApi",
                routeTemplate: "api/recipes/{action}/{id}",
                defaults: new
                {
                    controller = "recipes"
                }
            );

            config.Routes.MapHttpRoute(
                name: "RecipesSimpleApi",
                routeTemplate: "api/recipes/{action}",
                defaults: new
                {
                    controller = "recipes"
                }
            );

            config.Routes.MapHttpRoute(
                name: "GetRecipesByCategoryApi",
                routeTemplate: "api/categories/{id}/recipes",
                defaults: new
                {
                    controller = "categories",
                    action = "recipes"
                }
            );

            config.Routes.MapHttpRoute(
               name: "CategoriesApi",
               routeTemplate: "api/categories/{action}",
               defaults: new
               {
                   controller = "categories"
               }
           );

            config.Routes.MapHttpRoute(
                name: "DeleteUsersApi",
                routeTemplate: "api/users/{id}/delete",
                defaults: new
                {
                    controller = "users",
                    action = "delete"
                }
            );

            config.Routes.MapHttpRoute(
                name: "PromoteUsersApi",
                routeTemplate: "api/users/{id}/promote",
                defaults: new
                {
                    controller = "users",
                    action = "promote"
                }
            );

            config.Routes.MapHttpRoute(
                name: "UpdateUsersApi",
                routeTemplate: "api/users/{id}/update",
                defaults: new
                {
                    controller = "users",
                    action = "update"
                }
            );

            config.Routes.MapHttpRoute(
                name: "UsersApi",
                routeTemplate: "api/users/{action}",
                defaults: new
                {
                    controller = "users"
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
