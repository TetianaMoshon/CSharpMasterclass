using CookiesCookbook;
using CookiesCookbook.App;
using CookiesCookbook.DataAccess;
using CookiesCookbook.FileAccess;
using CookiesCookbook.Recipes;
using CookiesCookbook.Recipes.Ingredients;

const FileFormat Format = FileFormat.Json;
IStringsRepo stringsRepo = Format == FileFormat.Json
    ? new StringsJsonRepo()
    : new StringsTextRepo();
IngredientsRepo ingredientsRepo = new IngredientsRepo();
RecipesRepo recipesRepo = new RecipesRepo(stringsRepo, ingredientsRepo);
RecipesUserInteraction recipesUserInteraction = new RecipesUserInteraction(ingredientsRepo);
CookiesRecipes cookiesRecipes = new CookiesRecipes(recipesRepo, recipesUserInteraction);
var filePath = "recipes." + FileFormatter.GetFormatString(Format);
cookiesRecipes.Run(filePath);