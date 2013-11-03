namespace Recipies.Data.Migrations
{
    using Recipies.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Recipies.Data.RecipesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Recipies.Data.RecipesContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            Category[] categories = new Category[] 
            {
                new Category { Title = "Main dish" },
                new Category { Title = "Desert" },
                new Category { Title = "Soup" },
                new Category { Title = "Appetizer" },
                new Category { Title = "Side dish" },
                new Category { Title = "Snack" },
                new Category { Title = "Salad" },
                new Category { Title = "Dinner" }
            };

            User[] users = new User[] 
            {
                new User { Username = "admina", Role = Role.Admin, AuthCode = "e58a64b61a78eea90b2f2ce1f624c6b94d32a9a9" },
                new User { Username = "peshoo", Role = Role.Client, AuthCode = "1e7b9163ac7d121cd7fd56bcbe641bbbe7749a68" },
                new User { Username = "mimeto", Role = Role.Client, AuthCode = "a02a7948aa2bcb63c0549794d075b4a584a7e5a7" },
            };

            #region Products
            
            Product[] products = new Product[]
            {
                new Product { Title = "acorn squash" },
                new Product { Title = "alfalfa sprouts" },
                new Product { Title = "almond" },
                new Product { Title = "anchovy" },
                new Product { Title = "anise" },
                new Product { Title = "appetizer" },
                new Product { Title = "appetite" },
                new Product { Title = "apple" },
                new Product { Title = "apricot" },
                new Product { Title = "artichoke" },
                new Product { Title = "asparagus" },
                new Product { Title = "aspic" },
                new Product { Title = "ate" },
                new Product { Title = "avocado" },
                new Product { Title = "bacon" },
                new Product { Title = "bagel" },
                new Product { Title = "bake" },
                new Product { Title = "baked Alaska" },
                new Product { Title = "bamboo shoots" },
                new Product { Title = "banana" },
                new Product { Title = "barbecue" },
                new Product { Title = "barley" },
                new Product { Title = "basil" },
                new Product { Title = "batter" },
                new Product { Title = "beancurd" },
                new Product { Title = "beans" },
                new Product { Title = "beef" },
                new Product { Title = "beet" },
                new Product { Title = "bell pepper" },
                new Product { Title = "berry" },
                new Product { Title = "biscuit" },
                new Product { Title = "bitter" },
                new Product { Title = "black beans" },
                new Product { Title = "blackberry" },
                new Product { Title = "black-eyed peas" },
                new Product { Title = "black tea" },
                new Product { Title = "bland" },
                new Product { Title = "blood orange" },
                new Product { Title = "blueberry" },
                new Product { Title = "boil" },
                new Product { Title = "bowl" },
                new Product { Title = "boysenberry" },
                new Product { Title = "bran" },
                new Product { Title = "bread" },
                new Product { Title = "breadfruit" },
                new Product { Title = "breakfast" },
                new Product { Title = "brisket" },
                new Product { Title = "broccoli" },
                new Product { Title = "broil" },
                new Product { Title = "brownie" },
                new Product { Title = "brown rice" },
                new Product { Title = "brunch" },
                new Product { Title = "Brussels sprouts" },
                new Product { Title = "buckwheat" },
                new Product { Title = "buns" },
                new Product { Title = "burrito" },
                new Product { Title = "butter" },
                new Product { Title = "butter bean" },
                new Product { Title = "cake" },
                new Product { Title = "calorie" },
                new Product { Title = "candy" },
                new Product { Title = "candy apple" },
                new Product { Title = "cantaloupe" },
                new Product { Title = "capers" },
                new Product { Title = "caramel" },
                new Product { Title = "caramel apple" },
                new Product { Title = "carbohydrate" },
                new Product { Title = "carrot" },
                new Product { Title = "cashew" },
                new Product { Title = "cassava" },
                new Product { Title = "casserole" },
                new Product { Title = "cater" },
                new Product { Title = "cauliflower" },
                new Product { Title = "caviar" },
                new Product { Title = "cayenne pepper" },
                new Product { Title = "celery" },
                new Product { Title = "cereal" },
                new Product { Title = "chard" },
                new Product { Title = "cheddar" },
                new Product { Title = "cheese" },
                new Product { Title = "cheesecake" },
                new Product { Title = "chef" },
                new Product { Title = "cherry" },
                new Product { Title = "chew" },
                new Product { Title = "chicken" },
                new Product { Title = "chick peas" },
                new Product { Title = "chili" },
                new Product { Title = "chips" },
                new Product { Title = "chives" },
                new Product { Title = "chocolate" },
                new Product { Title = "chopsticks" },
                new Product { Title = "chow" },
                new Product { Title = "chutney" },
                new Product { Title = "cilantro" },
                new Product { Title = "cinnamon" },
                new Product { Title = "citron" },
                new Product { Title = "citrus" },
                new Product { Title = "clam" },
                new Product { Title = "cloves" },
                new Product { Title = "cobbler" },
                new Product { Title = "coconut" },
                new Product { Title = "cod" },
                new Product { Title = "coffee" },
                new Product { Title = "coleslaw" },
                new Product { Title = "collard greens" },
                new Product { Title = "comestibles" },
                new Product { Title = "cook" },
                new Product { Title = "cookbook" },
                new Product { Title = "cookie" },
                new Product { Title = "corn" },
                new Product { Title = "cornflakes" },
                new Product { Title = "cornmeal" },
                new Product { Title = "cottage cheese" },
                new Product { Title = "crab" },
                new Product { Title = "crackers" },
                new Product { Title = "cranberry" },
                new Product { Title = "cream" },
                new Product { Title = "cream cheese" },
                new Product { Title = "crepe" },
                new Product { Title = "crisp" },
                new Product { Title = "crunch" },
                new Product { Title = "crust" },
                new Product { Title = "cucumber" },
                new Product { Title = "cuisine" },
                new Product { Title = "cupboard" },
                new Product { Title = "cupcake" },
                new Product { Title = "curds" },
                new Product { Title = "currants" },
                new Product { Title = "curry" },
                new Product { Title = "custard" },
                new Product { Title = "daikon" },
                new Product { Title = "daily bread" },
                new Product { Title = "dairy" },
                new Product { Title = "dandelion greens" },
                new Product { Title = "Danish pastry" },
                new Product { Title = "dates" },
                new Product { Title = "dessert" },
                new Product { Title = "diet" },
                new Product { Title = "digest" },
                new Product { Title = "digestive system" },
                new Product { Title = "dill" },
                new Product { Title = "dine" },
                new Product { Title = "diner" },
                new Product { Title = "dinner" },
                new Product { Title = "dip" },
                new Product { Title = "dish" },
                new Product { Title = "dough" },
                new Product { Title = "doughnut" },
                new Product { Title = "dragonfruit" },
                new Product { Title = "dressing" },
                new Product { Title = "dried" },
                new Product { Title = "drink" },
                new Product { Title = "dry" },
                new Product { Title = "durian" },
                new Product { Title = "eat" },
                new Product { Title = "Edam cheese" },
                new Product { Title = "edible" },
                new Product { Title = "egg" },
                new Product { Title = "eggplant" },
                new Product { Title = "elderberry" },
                new Product { Title = "endive" },
                new Product { Title = "entree" },
                new Product { Title = "fast" },
                new Product { Title = "fat" },
                new Product { Title = "fava bans" },
                new Product { Title = "feast" },
                new Product { Title = "fed" },
                new Product { Title = "feed" },
                new Product { Title = "fennel" },
                new Product { Title = "fig" },
                new Product { Title = "fillet" },
                new Product { Title = "fire" },
                new Product { Title = "fish" },
                new Product { Title = "flan" },
                new Product { Title = "flax" },
                new Product { Title = "flour" },
                new Product { Title = "food" },
                new Product { Title = "food pyramid" },
                new Product { Title = "foodstuffs" },
                new Product { Title = "fork" },
                new Product { Title = "freezer" },
                new Product { Title = "French fries" },
                new Product { Title = "fried" },
                new Product { Title = "fritter" },
                new Product { Title = "frosting" },
                new Product { Title = "fruit" },
                new Product { Title = "fry" },
                new Product { Title = "garlic" },
                new Product { Title = "gastronomy" },
                new Product { Title = "gelatin" },
                new Product { Title = "ginger" },
                new Product { Title = "gingerale" },
                new Product { Title = "gingerbread" },
                new Product { Title = "glasses" },
                new Product { Title = "Gouda cheese" },
                new Product { Title = "grain" },
                new Product { Title = "granola" },
                new Product { Title = "grape" },
                new Product { Title = "grapefruit" },
                new Product { Title = "grated" },
                new Product { Title = "gravy" },
                new Product { Title = "greenbean" },
                new Product { Title = "greens" },
                new Product { Title = "green tea" },
                new Product { Title = "grub" },
                new Product { Title = "guacamole" },
                new Product { Title = "guava" },
                new Product { Title = "gyro" },
                new Product { Title = "herbs" },
                new Product { Title = "halibut" },
                new Product { Title = "ham" },
                new Product { Title = "hamburger" },
                new Product { Title = "hash" },
                new Product { Title = "hazelnut" },
                new Product { Title = "herbs" },
                new Product { Title = "honey" },
                new Product { Title = "honeydew" },
                new Product { Title = "horseradish" },
                new Product { Title = "hot" },
                new Product { Title = "hot dog" },
                new Product { Title = "hot sauce" },
                new Product { Title = "hummus" },
                new Product { Title = "hunger" },
                new Product { Title = "hungry" },
                new Product { Title = "ice" },
                new Product { Title = "iceberg lettuce" },
                new Product { Title = "iced tea" },
                new Product { Title = "icing" },
                new Product { Title = "ice cream" },
                new Product { Title = "ice cream cone" },
                new Product { Title = "jackfruit" },
                new Product { Title = "jalapeno" },
                new Product { Title = "jam" },
                new Product { Title = "jelly" },
                new Product { Title = "jellybeans" },
                new Product { Title = "jicama" },
                new Product { Title = "jimmies" },
                new Product { Title = "Jordan almonds" },
                new Product { Title = "jug" },
                new Product { Title = "julienne" },
                new Product { Title = "juice" },
                new Product { Title = "junk food" },
                new Product { Title = "kale" },
                new Product { Title = "kebab" },
                new Product { Title = "ketchup" },
                new Product { Title = "kettle" },
                new Product { Title = "kettle corn" },
                new Product { Title = "kidney beans" },
                new Product { Title = "kitchen" },
                new Product { Title = "kiwi" },
                new Product { Title = "knife" },
                new Product { Title = "kohlrabi" },
                new Product { Title = "kumquat" },
                new Product { Title = "ladle" },
                new Product { Title = "lamb" },
                new Product { Title = "lard" },
                new Product { Title = "lasagna" },
                new Product { Title = "legumes" },
                new Product { Title = "lemon" },
                new Product { Title = "lemonade" },
                new Product { Title = "lentils" },
                new Product { Title = "lettuce" },
                new Product { Title = "licorice" },
                new Product { Title = "lima beans" },
                new Product { Title = "lime" },
                new Product { Title = "liver" },
                new Product { Title = "loaf" },
                new Product { Title = "lobster" },
                new Product { Title = "lollipop" },
                new Product { Title = "loquat" },
                new Product { Title = "lox" },
                new Product { Title = "lunch" },
                new Product { Title = "lunch box" },
                new Product { Title = "lunchmeat" },
                new Product { Title = "lychee" },
                new Product { Title = "macaroni" },
                new Product { Title = "macaroon" },
                new Product { Title = "main course" },
                new Product { Title = "maize" },
                new Product { Title = "mandarin orange" },
                new Product { Title = "mango" },
                new Product { Title = "maple syrup" },
                new Product { Title = "margarine" },
                new Product { Title = "marionberry" },
                new Product { Title = "marmalade" },
                new Product { Title = "marshmallow" },
                new Product { Title = "mashed potatoes" },
                new Product { Title = "mayonnaise" },
                new Product { Title = "meat" },
                new Product { Title = "meatball" },
                new Product { Title = "meatloaf" },
                new Product { Title = "melon" },
                new Product { Title = "menu" },
                new Product { Title = "meringue" },
                new Product { Title = "micronutrient" },
                new Product { Title = "milk" },
                new Product { Title = "milkshake" },
                new Product { Title = "millet" },
                new Product { Title = "mincemeat" },
                new Product { Title = "minerals" },
                new Product { Title = "mint" },
                new Product { Title = "mints" },
                new Product { Title = "mochi" },
                new Product { Title = "molasses" },
                new Product { Title = "mole sauce" },
                new Product { Title = "mozzarella" },
                new Product { Title = "muffin" },
                new Product { Title = "mug" },
                new Product { Title = "munch" },
                new Product { Title = "mushroom" },
                new Product { Title = "mussels" },
                new Product { Title = "mustard" },
                new Product { Title = "mustard greens" },
                new Product { Title = "mutton" },
                new Product { Title = "napkin" },
                new Product { Title = "nectar" },
                new Product { Title = "nectarine" },
                new Product { Title = "nibble" },
                new Product { Title = "noodles" },
                new Product { Title = "nosh" },
                new Product { Title = "nourish" },
                new Product { Title = "nourishment" },
                new Product { Title = "nut" },
                new Product { Title = "nutmeg" },
                new Product { Title = "nutrient" },
                new Product { Title = "nutrition" },
                new Product { Title = "nutritious" },
                new Product { Title = "oats" },
                new Product { Title = "oatmeal" },
                new Product { Title = "oil" },
                new Product { Title = "okra" },
                new Product { Title = "oleo" },
                new Product { Title = "olive" },
                new Product { Title = "omelet" },
                new Product { Title = "omnivore" },
                new Product { Title = "onion" },
                new Product { Title = "orange" },
                new Product { Title = "order" },
                new Product { Title = "oregano" },
                new Product { Title = "oven" },
                new Product { Title = "oyster" },
                new Product { Title = "pan" },
                new Product { Title = "pancake" },
                new Product { Title = "papaya" },
                new Product { Title = "parsley" },
                new Product { Title = "parsnip" },
                new Product { Title = "pasta" },
                new Product { Title = "pastry" },
                new Product { Title = "pate" },
                new Product { Title = "patty" },
                new Product { Title = "pattypan squash" },
                new Product { Title = "peach" },
                new Product { Title = "peanut" },
                new Product { Title = "peanut butter" },
                new Product { Title = "pea" },
                new Product { Title = "pear" },
                new Product { Title = "pecan" },
                new Product { Title = "peapod" },
                new Product { Title = "pepper" },
                new Product { Title = "pepperoni" },
                new Product { Title = "persimmon" },
                new Product { Title = "pickle" },
                new Product { Title = "picnic" },
                new Product { Title = "pie" },
                new Product { Title = "pilaf" },
                new Product { Title = "pineapple" },
                new Product { Title = "pita bread" },
                new Product { Title = "pitcher" },
                new Product { Title = "pizza" },
                new Product { Title = "plate" },
                new Product { Title = "platter" },
                new Product { Title = "plum" },
                new Product { Title = "poached" },
                new Product { Title = "pomegranate" },
                new Product { Title = "pomelo" },
                new Product { Title = "pop" },
                new Product { Title = "popsicle" },
                new Product { Title = "popcorn" },
                new Product { Title = "popovers" },
                new Product { Title = "pork" },
                new Product { Title = "pork chops" },
                new Product { Title = "pot" },
                new Product { Title = "potato" },
                new Product { Title = "pot roast" },
                new Product { Title = "preserves" },
                new Product { Title = "pretzel" },
                new Product { Title = "prime rib" },
                new Product { Title = "protein" },
                new Product { Title = "provisions" },
                new Product { Title = "prune" },
                new Product { Title = "pudding" },
                new Product { Title = "pumpernickel" },
                new Product { Title = "pumpkin" },
                new Product { Title = "punch" },
                new Product { Title = "quiche" },
                new Product { Title = "quinoa" },
                new Product { Title = "radish" },
                new Product { Title = "raisin" },
                new Product { Title = "raspberry" },
                new Product { Title = "rations" },
                new Product { Title = "ravioli" },
                new Product { Title = "recipe" },
                new Product { Title = "refreshments" },
                new Product { Title = "refrigerator" },
                new Product { Title = "relish" },
                new Product { Title = "restaurant" },
                new Product { Title = "rhubarb" },
                new Product { Title = "ribs" },
                new Product { Title = "rice" },
                new Product { Title = "roast" },
                new Product { Title = "roll" },
                new Product { Title = "rolling pin" },
                new Product { Title = "romaine" },
                new Product { Title = "rosemary" },
                new Product { Title = "rye" },
                new Product { Title = "saffron" },
                new Product { Title = "sage" },
                new Product { Title = "salad" },
                new Product { Title = "salami" },
                new Product { Title = "salmon" },
                new Product { Title = "salsa" },
                new Product { Title = "salt" },
                new Product { Title = "sandwich" },
                new Product { Title = "sauce" },
                new Product { Title = "sauerkraut" },
                new Product { Title = "sausage" },
                new Product { Title = "savory" },
                new Product { Title = "scallops" },
                new Product { Title = "scrambled" },
                new Product { Title = "seaweed" },
                new Product { Title = "seeds" },
                new Product { Title = "sesame seed" },
                new Product { Title = "shallots" },
                new Product { Title = "sherbet" },
                new Product { Title = "shish kebab" },
                new Product { Title = "shrimp" },
                new Product { Title = "slaw" },
                new Product { Title = "slice" },
                new Product { Title = "smoked" },
                new Product { Title = "snack" },
                new Product { Title = "soda" },
                new Product { Title = "soda bread" },
                new Product { Title = "sole" },
                new Product { Title = "sorbet" },
                new Product { Title = "sorghum" },
                new Product { Title = "sorrel" },
                new Product { Title = "soup" },
                new Product { Title = "sour" },
                new Product { Title = "sour cream" },
                new Product { Title = "soy" },
                new Product { Title = "soybeans" },
                new Product { Title = "soysauce" },
                new Product { Title = "spaghetti" },
                new Product { Title = "spareribs" },
                new Product { Title = "spatula" },
                new Product { Title = "spices" },
                new Product { Title = "spicy" },
                new Product { Title = "spinach" },
                new Product { Title = "split peas" },
                new Product { Title = "spoon" },
                new Product { Title = "spork" },
                new Product { Title = "sprinkles" },
                new Product { Title = "sprouts" },
                new Product { Title = "spuds" },
                new Product { Title = "squash" },
                new Product { Title = "squid" },
                new Product { Title = "steak" },
                new Product { Title = "stew" },
                new Product { Title = "stir-fry" },
                new Product { Title = "stomach" },
                new Product { Title = "stove" },
                new Product { Title = "straw" },
                new Product { Title = "strawberry" },
                new Product { Title = "string bean" },
                new Product { Title = "stringy" },
                new Product { Title = "strudel" },
                new Product { Title = "sub sandwich" },
                new Product { Title = "submarine sandwich" },
                new Product { Title = "succotash" },
                new Product { Title = "suet" },
                new Product { Title = "sugar" },
                new Product { Title = "summer squash" },
                new Product { Title = "sundae" },
                new Product { Title = "sunflower" },
                new Product { Title = "supper" },
                new Product { Title = "sushi" },
                new Product { Title = "sustenance" },
                new Product { Title = "sweet" },
                new Product { Title = "sweet potato" },
                new Product { Title = "Swiss chard" },
                new Product { Title = "syrup" },
                new Product { Title = "taco" },
                new Product { Title = "take-out" },
                new Product { Title = "tamale" },
                new Product { Title = "tangerine" },
                new Product { Title = "tapioca" },
                new Product { Title = "taro" },
                new Product { Title = "tarragon" },
                new Product { Title = "tart" },
                new Product { Title = "tea" },
                new Product { Title = "teapot" },
                new Product { Title = "teriyaki" },
                new Product { Title = "thyme" },
                new Product { Title = "toast" },
                new Product { Title = "toaster" },
                new Product { Title = "toffee" },
                new Product { Title = "tofu" },
                new Product { Title = "tomatillo" },
                new Product { Title = "tomato" },
                new Product { Title = "torte" },
                new Product { Title = "tortilla" },
                new Product { Title = "tuber" },
                new Product { Title = "tuna" },
                new Product { Title = "turkey" },
                new Product { Title = "turmeric" },
                new Product { Title = "turnip" },
                new Product { Title = "ugli fruit" },
                new Product { Title = "unleavened" },
                new Product { Title = "utensils" },
                new Product { Title = "vanilla" },
                new Product { Title = "veal" },
                new Product { Title = "vegetable" },
                new Product { Title = "venison" },
                new Product { Title = "vinegar" },
                new Product { Title = "vitamin" },
                new Product { Title = "wafer" },
                new Product { Title = "waffle" },
                new Product { Title = "walnut" },
                new Product { Title = "wasabi" },
                new Product { Title = "water" },
                new Product { Title = "water chestnut" },
                new Product { Title = "watercress" },
                new Product { Title = "watermelon" },
                new Product { Title = "wheat" },
                new Product { Title = "whey" },
                new Product { Title = "whipped cream" },
                new Product { Title = "wok" },
                new Product { Title = "yam" },
                new Product { Title = "yeast" },
                new Product { Title = "yogurt" },
                new Product { Title = "yolk" },
                new Product { Title = "zucchini" },
            };

            #endregion

            List<List<Ingredient>> ingredians = new List<List<Ingredient>>() 
            { 
                new List<Ingredient>
            {
                new Ingredient {  Product = products[249], Mesaurement = Measurement.Piece,  Quantity = 2 },
                new Ingredient {  Product = products[7], Mesaurement = Measurement.Piece, Quantity = 1 },
                new Ingredient {  Product = products[398], Mesaurement = Measurement.Piece, Quantity = 150 },
                new Ingredient {  Product = products[472], Mesaurement = Measurement.Gram, Quantity = 500 },
                new Ingredient {  Product = products[480], Mesaurement = Measurement.Tablespoons, Quantity = 3 },
                new Ingredient {  Product = products[384], Mesaurement = Measurement.Tablespoons, Quantity = 3 },
                new Ingredient {  Product = products[510], Mesaurement = Measurement.Piece, Quantity = 10 },
                new Ingredient {  Product = products[94], Mesaurement = Measurement.ByTaste},
            },


             new List<Ingredient>
            {
                new Ingredient {  Product = products[56], Mesaurement = Measurement.Gram,  Quantity = 200 },
                new Ingredient {  Product = products[89], Mesaurement = Measurement.Gram, Quantity = 300 },
                new Ingredient {  Product = products[480], Mesaurement = Measurement.Gram, Quantity = 100 },
                new Ingredient {  Product = products[472], Mesaurement = Measurement.Gram, Quantity = 500 },
                new Ingredient {  Product = products[421], Mesaurement = Measurement.Pinch},
                new Ingredient {  Product = products[175], Mesaurement = Measurement.Teaspoon, Quantity = 4 },
                new Ingredient {  Product = products[398], Mesaurement = Measurement.Gram, Quantity = 200 },
                
            },

           new List<Ingredient>
            {
                new Ingredient {  Product = products[523], Mesaurement = Measurement.Mililiter,  Quantity = 200 },
                new Ingredient {  Product = products[335], Mesaurement = Measurement.Piece, Quantity = 1 },
                new Ingredient {  Product = products[480], Mesaurement = Measurement.Gram, Quantity = 100 },
                new Ingredient {  Product = products[140], Mesaurement = Measurement.ByTaste},
            },


             new List<Ingredient>
            {
                new Ingredient {  Product = products[508], Mesaurement = Measurement.Piece,  Quantity = 2 },
                new Ingredient {  Product = products[335], Mesaurement = Measurement.Gram, Quantity = 50 },
                new Ingredient {  Product = products[187], Mesaurement = Measurement.Teaspoon, Quantity = 1 },
                new Ingredient {  Product = products[264],  Mesaurement = Measurement.Mililiter, Quantity = 75},
                new Ingredient {  Product = products[421],  Mesaurement = Measurement.Teaspoon, Quantity = 1},
                new Ingredient {  Product = products[93],  Mesaurement = Measurement.Tablespoons},
            }
            };

            
            var first =    new Recipe 
                { 
                    Title = "Annie's Fruit Salsa and Cinnamon Chips", 
                    Category = categories[1], Creator = users[0], 
                    Content = @"In a large bowl, thoroughly mix kiwis, 
                                Golden Delicious apples, raspberries, strawberries,
                                white sugar, brown sugar and fruit preserves. Cover
                                and chill in the refrigerator at least 15 minutes.
                                Preheat oven to 350 degrees F (175 degrees C).
                                Coat one side of each flour tortilla with butter 
                                flavored cooking spray. Cut into wedges and arrange 
                                in a single layer on a large baking sheet. Sprinkle 
                                wedges with desired amount of cinnamon sugar.
                                Spray again with cooking spray.
                                Bake in the preheated oven 8 to 10 minutes.
                                Repeat with any remaining tortilla wedges.
                                Allow to cool approximately 15 minutes. 
                                Serve with chilled fruit mixture.", 
                  
                    Fans = new User[] { users[1], users[2] } ,
                    PublishDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                };
               var second = new Recipe 
                { 
                    Title = "Molten Chocolate Cakes With Sugar-Coated Raspberries", 
                    Category = categories[1], Creator = users[0], 
                    Content = @"Melt butter and chocolate in a medium heat-proof bowl over a saucepan
                                of simmering water; remove from heat. Beat eggs, sugar and salt with 
                                a hand mixer in a medium bowl until sugar dissolves. Beat egg mixture 
                                into chocolate until smooth. Beat in flour or matzo meal until just combined.
                                (Batter can be made a day ahead; return to room temperature an hour or so before
                                baking.)
                                Before serving dinner, adjust oven rack to middle position; heat oven to 450 
                                degrees. Line a standard-size muffin tin (1/2 cup capacity) with 8 extra-large 
                                muffin papers (papers should extend above cups to facilitate removal). 
                                Spray muffin papers with vegetable cooking spray. Divide batter among muffin cups.
                                Bake until batter puffs but center is not set, 8 to 10 minutes. 
                                Carefully lift cakes from tin and set on a work surface. 
                                Pull papers away from cakes and transfer cakes to dessert plates.
                                Top each with sugared raspberries and serve immediately.", 
                   
                    Fans = new User[] { users[1], users[2] },
                    PublishDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                };

                var third = new Recipe 
                { 
                    Title =    "Adrienne's Cucumber Salad", 
                    Category = categories[6], Creator = users[0], 
                    Content = @"Toss together the cucumbers and onion in a large bowl. 
                                Combine the vinegar, water and sugar in a saucepan over medium-high heat.
                                Bring to a boil, and pour over the cucumber and onions. 
                                Stir in dill, cover, and refrigerate until cold.
                                This can also be eaten at room temperature,
                                but be sure to allow the cucumbers to marinate for at least 1 hour.",

                    PublishDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                };

                var fourth = new Recipe 
                { 
                    Title =    "D's Famous Salsa", 
                    Category = categories[3], Creator = users[2], 
                    Content = @"Place the tomatoes, onion, garlic, lime 
                                juice, salt, green chiles, and cilantro 
                                in a blender or food processor. 
                                Blend on low to desired consistency.",

                    PublishDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                };
           


            for (int i = 0; i < products.Length; i++)
            {
                var title = products[i].Title;
                if (context.Products.FirstOrDefault(p => p.Title == title) == null)
                {
                    context.Products.Add(products[i]);
                }
                
            }

            for (int i = 0; i < categories.Length; i++)
            {
                var title = categories[i].Title;
                if (context.Categories.FirstOrDefault(p => p.Title == title) == null)
                {
                    context.Categories.Add(categories[i]);
                }

            }

            for (int i = 0; i < users.Length; i++)
            {
                var username = users[i].Username;
                if (context.Users.FirstOrDefault(p => p.Username == username) == null)
                {
                    context.Users.Add(users[i]);
                }
            }

            if ((context.Recipes.FirstOrDefault(r => r.Title == first.Title) == null))
            {
                context.Recipes.Add(first);

                for (int j = 0; j < ingredians[0].Count; j++)
                {
                    ingredians[0][j].Recipe = first;
                    context.Ingredients.Add(ingredians[0][j]);

                }
            }

            if ((context.Recipes.FirstOrDefault(r => r.Title == second.Title) == null))
            {
                context.Recipes.AddOrUpdate(
                   u => u.Title,
                  second);


                for (int j = 0; j < ingredians[1].Count; j++)
                {
                    ingredians[1][j].Recipe = second;
                    context.Ingredients.Add(ingredians[1][j]);

                }
            }

            if ((context.Recipes.FirstOrDefault(r => r.Title == third.Title) == null))
            {
                context.Recipes.AddOrUpdate(
                   u => u.Title,
                  third);

                for (int j = 0; j < ingredians[2].Count; j++)
                {
                    ingredians[2][j].Recipe = third;
                    context.Ingredients.Add(ingredians[2][j]);

                }
            }

            if ((context.Recipes.FirstOrDefault(r => r.Title == fourth.Title) == null))
            {
                context.Recipes.AddOrUpdate(
                   u => u.Title,
                  fourth);

                for (int j = 0; j < ingredians[3].Count; j++)
                {
                    ingredians[3][j].Recipe = fourth;
                    context.Ingredients.Add(ingredians[3][j]);

                }
            } 
        }
    }
}
