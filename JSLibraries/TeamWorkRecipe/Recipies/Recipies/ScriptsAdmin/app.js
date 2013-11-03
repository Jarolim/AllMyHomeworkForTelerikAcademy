/// <reference path="libs/angular.js" />
/// <reference path="_references.js" />

    //require.config({
    //    paths: {
    //        jquery: "libs/jquery-2.0.3",
    //        "Class": "libs/class",
    //        underscore: "libs/underscore",
    //        //cryptoJS: "libs/sha1",
    //        "angular": "libs/angular",
    //        controller: "app/controller",
    //        data: "app/data"
    //    },
    //    shim: {
    //        "angular": {
    //            exports: "angular"
    //        }
    //    }
    //});

    //require(["angular", "controller"], function (angular, controller) {

    angular.module("recipe-book", [])
            .config(["$routeProvider", function ($routeProvider) {
                $routeProvider
                    .when("/", {
                        templateUrl: "ScriptsAdmin/partials/main-nav-view.html",
                        controller: HomeController
                    })
                    .when("/404", {
                        templateUrl: "ScriptsAdmin/partials/404.html"
                    })
                    .when("/login", {
                        templateUrl: "ScriptsAdmin/partials/login-form.html",
                        controller: LoginController
                    })
                    .when("/users", {
                        templateUrl: "ScriptsAdmin/partials/all-users-view.html",
                        controller: UserController
                    })
                    .when("/users/:id", {
                        templateUrl: "ScriptsAdmin/partials/single-user-view.html",
                        controller: SingleUserController
                    })
                    .when("/categories", {
                        templateUrl: "ScriptsAdmin/partials/all-categories-view.html",
                        controller: CategoryController
                    })
                    .when("/categories/:id", {
                        templateUrl: "ScriptsAdmin/partials/single-category-view.html",
                        controller: SingleCategoryController
                    })
                    .when("/recipes", {
                        templateUrl: "ScriptsAdmin/partials/all-recipes-view.html",
                        controller: RecipeController
                    })
                     .when("/recipes/:id", {
                         templateUrl: "ScriptsAdmin/partials/single-recipe-view.html",
                         controller: SingleRecipeController
                     })
                    .otherwise({ redirectTo: "/" });
            }]);

    //});