namespace src.Models
{
    public class Cocktail
    {
        public int CocktailId { get; set; }
        public string Name { get; set; }
        public string Strength { get; set; }
        public List<RecipeIngredient> Ingredients { get; set; }
        public List<Instruction> Instructions { get; set; }
    }
}
