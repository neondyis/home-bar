using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace src.Models;

public class Ingredient
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IngredientId { get; set; }
    public String Name { get; set; }
    [ForeignKey("BrandId")]
    public Brand Brand { get; set; }
    public String Type { get; set; }
}