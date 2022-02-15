using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models
{
    public class Cocktail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CocktailId { get; set; }
        public string Name { get; set; }
        public string Strength { get; set; }
        public virtual ICollection<RecipeIngredient> Ingredients { get; set; }
        public virtual ICollection<Instruction> Instructions { get; set; }
    }
}
