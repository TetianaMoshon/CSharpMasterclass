namespace CookiesCookbook.Recipes.Ingredients;

public class IngredientsRepo
{
    // collection expressions
    // public List<Ingredient> AllIngredients { get; } = new List<Ingredient>
    // {
    //     new Flour(),
    //     new Butter(),
    //     new Chocolate(),
    //     new Sugar(),
    // };
    public List<Ingredient> AllIngredients { get; } = [
        new Flour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
    ];
    
    public Ingredient? GetById(int id)
    {
        return AllIngredients.Find(x => x.Id == id);
    }
}