using Microsoft.EntityFrameworkCore;
using src.Models;


namespace src
{
    public class BarContext : DbContext
    {
        public BarContext(DbContextOptions<BarContext> options) : base(options) { }

        public  DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Liqueur> Liquers { get; set; }
        public virtual DbSet<Liquor> Liquors { get; set; }
        public virtual DbSet<Fruit> Fruits { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Mixer> Mixers { get; set; }
        public virtual DbSet<Garnish> Garnishes { get; set; }
        public virtual DbSet<Glass> Glasses { get; set; }
        public virtual DbSet<Syrup> Syrups { get; set; }
        public virtual DbSet<Measurement> Measurements { get; set; }
        public virtual DbSet<MeasurementType> MeasurementTypes { get; set; }
        public virtual DbSet<Cocktail> Cocktails { get; set; }
        public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public virtual DbSet<Instruction> Instructions { get; set; }
        public virtual DbSet<InstructionStep> InstructionSteps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Brand Table
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(b => b.BrandId);

                entity.ToTable("brands");

                entity.Property(b => b.BrandId)
                    .IsRequired()
                    .HasColumnName("brand_id");

                entity.Property(b => b.BrandName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("brand_name");

                entity.HasMany(b => b.Ingredients)
                    .WithOne(i => i.Brand)
                    .HasForeignKey(s => s.BrandId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            
            // Cocktail Table
            modelBuilder.Entity<Cocktail>(entity =>
            {
                entity.HasKey(c => c.CocktailId);

                entity.ToTable("cocktails");

                entity.Property(c => c.CocktailId)
                    .IsRequired()
                    .HasColumnName("cocktail_id");

                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("cocktail_name");
                
                entity.Property(c => c.Strength)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("cocktail_strength");
                
                entity.HasMany(b => b.Ingredients)
                    .WithOne(i => i.Cocktail)
                    .HasForeignKey(s => s.CocktailId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                entity.HasMany(b => b.Instructions)
                    .WithOne(i => i.Cocktail)
                    .HasForeignKey(s => s.CocktailId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            
            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(c => c.IngredientId);

                entity.ToTable("ingredients");
                
                entity.Property(c => c.IngredientId)
                    .IsRequired()
                    .HasColumnName("ingredient_id");

                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("ingredient_name");
            });

            // Fruit Table
            modelBuilder.Entity<Fruit>(entity =>
            {
                entity.ToTable("ingredients");

                entity.HasBaseType<Ingredient>();

                entity.HasDiscriminator().HasValue("Fruit");
                
                entity.Property(c => c.Type)
                    .IsRequired()
                    .HasDefaultValue("Fruit")
                    .HasMaxLength(255)
                    .HasColumnName("ingredient_type");
            });
            
            modelBuilder.Entity<Garnish>(entity =>
            {
                entity.ToTable("ingredients");

                entity.HasBaseType<Ingredient>();

                entity.HasDiscriminator().HasValue("Garnish");
                
                entity.Property(c => c.Type)
                    .IsRequired()
                    .HasDefaultValue("Garnish")
                    .HasMaxLength(255)
                    .HasColumnName("ingredient_type");
            });
            
            modelBuilder.Entity<Glass>(entity =>
            {
                entity.HasKey(c => c.GlassId);

                entity.ToTable("glasses");

                entity.Property(c => c.GlassId)
                    .IsRequired()
                    .HasColumnName("glass_id");

                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("glass_name");
            });
            
            modelBuilder.Entity<Liqueur>(entity =>
            {
                entity.ToTable("ingredients");
                
                entity.HasBaseType<Ingredient>();

                entity.HasDiscriminator().HasValue("Liqueur");

                entity.Property(c => c.IngredientId)
                    .IsRequired()
                    .HasColumnName("liqueur_id");

                entity.Property(c => c.Percentage)
                    .IsRequired()
                    .HasColumnName("liqueur_percentage");
                
                entity.Property(c => c.Type)
                    .IsRequired()
                    .HasDefaultValue("Liqueur")
                    .HasMaxLength(255)
                    .HasColumnName("ingredient_type");
            });

            modelBuilder.Entity<Liquor>(entity =>
            {
                entity.ToTable("ingredients");
                
                entity.HasBaseType<Ingredient>();

                entity.HasDiscriminator().HasValue("Liquor");

                entity.Property(c => c.Percentage)
                    .IsRequired()
                    .HasColumnName("liquor_percentage");
                
                entity.Property(c => c.Type)
                    .IsRequired()
                    .HasDefaultValue("Liquor")
                    .HasMaxLength(255)
                    .HasColumnName("ingredient_type");
            });
            
            modelBuilder.Entity<Mixer>(entity =>
            {
                entity.ToTable("ingredients");
                
                entity.HasBaseType<Ingredient>();

                entity.HasDiscriminator().HasValue("Mixer");
                
                entity.Property(c => c.Type)
                    .IsRequired()
                    .HasDefaultValue("Mixer")
                    .HasMaxLength(255)
                    .HasColumnName("ingredient_type");
            });
            
            modelBuilder.Entity<Syrup>(entity =>
            {

                entity.ToTable("ingredients");

                entity.HasBaseType<Ingredient>();

                entity.HasDiscriminator().HasValue("Syrup");
                
                entity.Property(c => c.Type)
                    .IsRequired()
                    .HasDefaultValue("Syrup")
                    .HasMaxLength(255)
                    .HasColumnName("ingredient_type");
            });
            
            modelBuilder.Entity<Instruction>(entity =>
            {
                entity.HasKey(c => c.InstructionId);

                entity.ToTable("instructions");

                entity.Property(c => c.InstructionId)
                    .IsRequired()
                    .HasColumnName("instruction_id");

                entity.HasMany(b => b.Steps)
                    .WithOne(i => i.Instruction)
                    .HasForeignKey(s => s.InstructionId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            
            modelBuilder.Entity<InstructionStep>(entity =>
            {
                entity.HasKey(c => c.InstructionId);

                entity.ToTable("instruction_steps");
                
                
                entity.Property(c => c.InstructionStepId)
                    .IsRequired()
                    .HasColumnName("step_id");

                
                entity.Property(c => c.Number)
                    .IsRequired()
                    .HasColumnName("step_number");
                
                entity.Property(c => c.Description)
                    .IsRequired()
                    .HasColumnName("step_description");
            });
            
            modelBuilder.Entity<Measurement>(entity =>
            {
                entity.HasKey(c => c.MeasurementId);

                entity.ToTable("measurements");

                entity.Property(c => c.MeasurementId)
                    .IsRequired()
                    .HasColumnName("instruction_id");

            });
            
            modelBuilder.Entity<MeasurementType>(entity =>
            {
                entity.HasKey(c => c.MeasurementTypeId);

                entity.ToTable("measurement_types");

                entity.Property(c => c.MeasurementTypeId)
                    .IsRequired()
                    .HasColumnName("measurement_type_id");
                
                entity.Property(c => c.Unit)
                    .IsRequired()
                    .HasColumnName("measurement_type_unit");
                
                entity.HasMany(b => b.Measurements)
                    .WithOne(i => i.Type)
                    .HasForeignKey(s => s.MeasurementTypeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            
            modelBuilder.Entity<RecipeIngredient>(entity =>
            {
                entity.HasKey(c => c.RecipeIngredientId);

                entity.ToTable("recipe_ingredients");

                entity.Property(c => c.RecipeIngredientId)
                    .IsRequired()
                    .HasColumnName("recipe_ingredient_id");
                
                entity.HasOne(q => q.Measurement)
                    .WithMany()
                    .HasForeignKey(s => s.MeasurementId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                entity.HasOne(q => q.Ingredient)
                    .WithMany()
                    .HasForeignKey(s => s.IngredientId)
                    .OnDelete(DeleteBehavior.Restrict);

            });
        }
    }
}
