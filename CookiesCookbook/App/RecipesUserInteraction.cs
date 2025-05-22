using CookiesCookbook.Recipes;
using CookiesCookbook.Recipes.Ingredients;

namespace CookiesCookbook.App;

public class RecipesUserInteraction(IngredientsRepo _ingredientsRepo)
{

    public void ShowIngredientsList()
    {
        Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
        foreach (var ingredient in _ingredientsRepo.AllIngredients)
        {
            Console.WriteLine(ingredient.Id + ". " + ingredient.Name);
        }
        Console.WriteLine();
    }

    public List<Ingredient> GetIngredientsFromUser()
    {
        Console.WriteLine("Selecting ingredients for a new recipe.");

        List<Ingredient> ingredients = [];
        bool isInputNumber = true;
        
        while (isInputNumber)
        {
            Console.WriteLine();
            Console.WriteLine("Please select an ingredient by entering its ID:");
            var input = Console.ReadLine();
            
            isInputNumber = int.TryParse(input, out int selectedIngredientId);
            if (isInputNumber) {
                var selectedIngredient = _ingredientsRepo.GetById(selectedIngredientId);
                if (selectedIngredient is not null) {
                    ingredients.Add(selectedIngredient);
                    Console.WriteLine("Ingredient added");
                }
            }
            else
            {
                Console.WriteLine("Nothing added.");
            }
        };
        return ingredients;
    }
    
    public void PrintExistingRecipes(List<Recipe> recipes)
    {
        if (recipes.Count > 0)
        {
            Console.WriteLine("Existing recipes are:" + Environment.NewLine);
            var counter = 1;
            foreach (var recipe in recipes)
            {
                Console.WriteLine($"***** {counter} *****");
                Console.WriteLine(recipe);
                Console.WriteLine();
                ++counter;
            }
        }
    }
    
    public void Exit()
    {
        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }
}