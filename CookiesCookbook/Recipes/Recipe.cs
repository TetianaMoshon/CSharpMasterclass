namespace CookiesCookbook.Recipes;

public class Recipe(List<Ingredient> ingredients)
// public class Recipe(List<Ingredient> Ingredients)
{
    public List<Ingredient> Ingredients { get; } = ingredients;
    
    public override string ToString()
    {
        var steps = new List<string>();
        foreach(var ingredient in Ingredients)
        {
            steps.Add($"{ingredient.Name}. {ingredient.Instruction}");
        }
        return string.Join(Environment.NewLine, steps);
    }
}