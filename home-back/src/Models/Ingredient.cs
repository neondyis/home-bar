namespace src.Models;

public class Ingredient
{
    public int IngredientId { get; set; }
    public String Name { get; set; }
    public Brand Brand { get; set; }
    public String Type { get; set; }
}