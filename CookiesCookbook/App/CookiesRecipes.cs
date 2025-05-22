using CookiesCookbook.Recipes;

namespace CookiesCookbook.App;

// Primary Constructor
// public class CookiesRecipes
public class CookiesRecipes(RecipesRepo _recipesRepo, RecipesUserInteraction _recipesUserInteraction)
{
    // private RecipesUserInteraction _recipesUserInteraction;
    //
    // public CookiesRecipes(RecipesUserInteraction recipesUserInteraction)
    // {
    //     _recipesUserInteraction = recipesUserInteraction;
    // }

    public void Run(string filePath)
    {
        var allRecipes = _recipesRepo.GetAllRecipes(filePath);
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);
        _recipesUserInteraction.ShowIngredientsList();
        var ingredients = _recipesUserInteraction.GetIngredientsFromUser();
        if (ingredients.Count() > 0)
        // if (ingredients.Any())
        {
            var recipe = new Recipe(ingredients);
            allRecipes.Add(recipe);
            _recipesRepo.AddRecipe(filePath, allRecipes);
            Console.WriteLine("Recipe added:");
            Console.WriteLine(recipe.ToString());
        }
        else
        {
            Console.WriteLine(
                "No ingredients have been selected. " +
                "Recipe will not be saved."
                );
        }
        _recipesUserInteraction.Exit();
    }
}