/// <reference path="_references.js" />


require.config({
    paths: {
        jquery: "libs/jquery-2.0.3",
        rsvp: "libs/rsvp.min",
        httpRequester: "libs/http-requester",
        dataProvider: "app/dataProvider",
        "class": "libs/class",
        cryptoJs: "libs/sha1",
        underscore: "libs/underscore",
        kendoWeb: "libs/kendo.web.min",
        persisters: "app/data"

    }
});

require(["jquery", "app/controller", "kendoWeb"], function ($, controller) {


    var router = new kendo.Router();

    var controllerFactory = controller.get();

    controllerFactory.loadNav();

    router.route("/", function () {
        controllerFactory.loadNav();

        controllerFactory.loadHomePage();

    });

    router.route("/auth", function () {
        controllerFactory.loadNav();

        controllerFactory.loadAuthPage()
            .then(function (data) {
                controllerFactory.loadNav();
                history.back();
            }, function (err) {
                history.back();
                console.log(err);
            });

    });

    // TO DO -think of better way
    router.route("/logout", function () {
        controllerFactory.loadNav();

        controllerFactory.processLogout()
             .then(function (data) {
                 controllerFactory.loadNav();
                 router.navigate("/");
             }, function (err) {
                 router.navigate("/");
             });
    });

    router.route("/categories/:id", function (id) {
        controllerFactory.loadNav();

        controllerFactory.loadRecipesByCategoryPage(id);
    });

    router.route("/recipe/:id", function (id) {
        controllerFactory.loadSingleRecipePage(id)

    });

    router.route("/addrecipe", function () {
        controllerFactory.loadNav();


        controllerFactory.loadCreateRecipePage()
         .then(function (id) {
             router.navigate("#/recipe/" + id);
         }, function (err) {
             router.navigate("/auth");
         });
    });


    router.route("/allRecipes", function () {
        controllerFactory.loadNav();

        controllerFactory.loadAllRecipes();

    });

    router.route("/recipes/favourites", function () {
        controllerFactory.loadFavouriteRecipes();

    });
    router.route("/recipes/my-recipes", function () {
        controllerFactory.loadMyRecipes();

    });


    $(function () {
        controllerFactory.loadNav();

        controllerFactory.renderLayouts();
        router.start("/");
    });
});