namespace src.Models;

public class RecipeIngredient
{
    public int RecipeIngredientId { get; set; }
    public Ingredient Ingredient { get; set; }
    public Measurement Measurement { get; set; }
}