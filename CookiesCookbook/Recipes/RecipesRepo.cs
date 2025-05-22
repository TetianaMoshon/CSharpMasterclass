using CookiesCookbook.DataAccess;
using CookiesCookbook.Recipes.Ingredients;

namespace CookiesCookbook.Recipes;

public class RecipesRepo(IStringsRepo _stringsRepo, IngredientsRepo _ingredientsRepo)
{
    private Recipe _RecipeFromString(string recipeString)
    {
        var ingredients = new List<Ingredient>();
        var recipeParts = recipeString.Split(",");

        foreach (var ingredientString in recipeParts)
        {
            var id = int.Parse(ingredientString);
            var ingredient = _ingredientsRepo.GetById(id);
            ingredients.Add(ingredient);
        }

        return new Recipe(ingredients);
    }

    public List<Recipe> GetAllRecipes(string filePath)
    {
        List<string> recipesFromFile = _stringsRepo.Read(filePath);
        var recipes = new List<Recipe>();
        foreach (var recipeFromFile in recipesFromFile)
        {
            var recipe = _RecipeFromString(recipeFromFile);
            recipes.Add(recipe);
        }

        return recipes;
    }
    
    public void AddRecipe(string filePath, List<Recipe> allRecipes)
    {
        var stringRecipes = new List<string>();
        foreach (var recipe in allRecipes)
        {
            var ingredientIds = new List<int>();
            foreach (var ingredient in recipe.Ingredients)
            {
                ingredientIds.Add(ingredient.Id);
            }
            stringRecipes.Add(string.Join(",", ingredientIds));
        }
        _stringsRepo.Write(filePath, stringRecipes);
    }
}