using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models
{
    public class Cocktail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CocktailId { get; set; }
        public string Name { get; set; }
        public string Strength { get; set; }
        public virtual List<RecipeIngredient> Ingredients { get; set; }
        public virtual List<Instruction> Instructions { get; set; }
    }
}
