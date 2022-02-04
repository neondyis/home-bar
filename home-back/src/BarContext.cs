using Microsoft.EntityFrameworkCore;
using src.Models;


namespace src
{
    public class BarContext : DbContext
    {
        public BarContext(DbContextOptions<BarContext> options) : base(options) { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Liqueur> Liquers { get; set; }
        public DbSet<Liquor> Liquors { get; set; }
        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Mixer> Mixers { get; set; }
        public DbSet<Garnish> Garnishes { get; set; }
        public DbSet<Glass> Glasses { get; set; }
        public DbSet<Syrup> Syrups { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<MeasurementType> MeasurementTypes { get; set; }
        public DbSet<Cocktail> Cocktails { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<InstructionStep> InstructionSteps { get; set; }
    }
}
