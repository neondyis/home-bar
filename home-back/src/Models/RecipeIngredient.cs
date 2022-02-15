using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models;

public class RecipeIngredient
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RecipeIngredientId { get; set; }
    public Ingredient Ingredient { get; set; }
    public Measurement Measurement { get; set; }
}