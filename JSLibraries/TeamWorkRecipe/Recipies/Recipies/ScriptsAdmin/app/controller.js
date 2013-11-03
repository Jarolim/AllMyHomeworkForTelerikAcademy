/// <reference path="../_references.js" />

//define(["angular", "data"], function (angular, persister) {

    if (!String.prototype.htmlEscape) {
        String.prototype.htmlEscape = function () {
            var escapedStr = String(this).replace(/&/g, '&amp;');
            escapedStr = escapedStr.replace(/</g, '&lt;');
            escapedStr = escapedStr.replace(/>/g, '&gt;');
            escapedStr = escapedStr.replace(/"/g, '&quot;');
            escapedStr = escapedStr.replace(/'/g, "&#39");
            return escapedStr;
        }
    }
    function HomeController($scope, $http) {
        var self = this;
        this.persister = persister.get($http, "/api");
        if (this.persister.isUserLoggedIn()) {
            document.location = "#/";
        } else {
            document.location = "#/login";
        }

        $scope.logoutUser = function () {
            if (self.persister.isUserLoggedIn()) {
                self.persister.user.logout(function () {
                    document.location = "#/login";
                }, function () {
                    alert("Cannot logout");
                });
                
            }
        }
    };

    function LoginController($scope, $http) {
        var self = this;
        this.persister = persister.get($http, "/api");
        $scope.user = {
            username: "",
            password: ""
        }
        $scope.message = "";
        $scope.loginUser = function () {
            var user = $scope.user;
            debugger;
            user.username = user.username.htmlEscape();
            user.password = user.password.htmlEscape();

            self.persister.user.login(user, function () {
                document.location = "#/";
            }, function () {
                $scope.message = "Invalid username or password";
            });
        }

    };

    function UserController($scope, $http, $routeParams) {
        var self = this;
        this.persister = persister.get($http, "/api");
        this.persister.user.getAll(function (users) {
            $scope.users = users;
        }, function () {
            alert("Cannot get users");
        });
    }
    
    function SingleUserController($scope, $http, $routeParams) {
        var self = this;
        this.persister = persister.get($http, "/api");
        $scope.user = {
            username: "",
            password: ""
        }
        $scope.password = "";
        $scope.message = "";
        var id = $routeParams["id"];
        this.persister.user.getAll(function (users) {
            $scope.user = _.first(_.filter(users, function (u) {
                return u.id == id;
            }));

            if ($scope.user == null) {
                document.location = "#/404";
            }

            $scope.changePassword = function () {
                var userData = {
                    id: id,
                    username: $scope.user.username.htmlEscape(),
                    password: $scope.password.htmlEscape()
                };
                self.persister.user.changePassword(userData, function () {
                    $scope.message = "Password Changed";
                }, function () {
                    $scope.message = "Cannot Change Password";
                });
            }
            $scope.promoteToAdmin = function () {
                var userData = {
                    id: id,
                };
                self.persister.user.promoteToAdmin(userData, function () {
                    $scope.message = "Promoted to Admin";
                }, function () {
                    $scope.message = "Cannot Promote to Admin";
                });
            }
            $scope.deleteUser = function () {
                var userData = {
                    id: id,
                };
                self.persister.user.deleteUser(userData, function () {
                    $scope.message = "User Deleted";
                }, function () {
                    $scope.message = "Cannot Delete User";
                });
            }

        }, function () {
            alert("Cannot get users");
        });
    }

    function CategoryController($scope, $http, $routeParams) {
        var self = this;
        this.persister = persister.get($http, "/api");
        this.persister.category.getAll(function (categories) {
            $scope.categories = categories;
        }, function () {
            alert("Cannot get categories");
        });
    }
    
    function SingleCategoryController($scope, $http, $routeParams) {
        var self = this;
        this.persister = persister.get($http, "/api");
        var id = $routeParams["id"];

        this.persister.category.getAll(function (categories) {
            $scope.category = _.first(_.filter(categories, function (c) {
                return c.id == id;
            }));

            if ($scope.category == null) {
                document.location = "#/404";
            }

            $scope.deleteCategory = function () {
               
                self.persister.category.deleteCategory(id, function () {
                    $scope.message = "Category Deleted";
                }, function () {
                    $scope.message = "Cannot Delete Category";
                });
            }

        }, function () {
            alert("Cannot get Recipe");
        });
    }

    function RecipeController($scope, $http, $routeParams) {
        var self = this;
        this.persister = persister.get($http, "/api");
        this.persister.recipe.getAll(function (recipes) {
            $scope.recipes = recipes;
        }, function () {
            alert("Cannot get recipes");
        });
    }

    function SingleRecipeController($scope, $http, $routeParams) {
        var self = this;
        this.persister = persister.get($http, "/api");

        var id = $routeParams["id"];

        this.persister.recipe.getWithId(id, function (recipe) {
            $scope.recipe = recipe;

            if ($scope.recipe == null) {
                document.location = "#/404";
            }

            $scope.deleteRecipe = function () {

                self.persister.recipe.deleteRecipe(id, function () {
                    $scope.message = "Recipe Deleted";
                }, function () {
                    $scope.message = "Cannot Delete Recipe";
                });
            }

        }, function () {
            alert("Cannot get Recipe");
        });
    }

//   return {
//       HomeController: HomeController,
//       LoginController: LoginController
//   }
//});