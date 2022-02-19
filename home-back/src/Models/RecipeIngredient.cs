using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models;

public class RecipeIngredient
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RecipeIngredientId { get; set; }
    public Ingredient? Ingredient { get; set; }
    public Measurement? Measurement { get; set; }
    
    public int MeasurementId { get; set; }
    
    public int IngredientId { get; set; }
    
    public int CocktailId { get; set; }

    public Cocktail? Cocktail { get; set; }
}