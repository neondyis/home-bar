using Microsoft.EntityFrameworkCore;
using src;
using src.GraphQL;
using src.Repositories;
using src.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
services.AddDbContext<BarContext>(options =>
    options.UseNpgsql(connectionString));

services.AddControllers();

// Registering Repositories

services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
services.AddTransient<IBrandRepository, BrandRepository>();
services.AddTransient<ICocktailRepository, CocktailRepository>();
services.AddTransient<IFruitRepository, FruitRepository>();
services.AddTransient<IGarnishRepository, GarnishRepository>();

services.AddTransient<IGlassRepository, GlassRepository>();
services.AddTransient<IIngredientRepository, IngredientRepository>();
services.AddTransient<IInstructionsRepository, InstructionRepository>();
services.AddTransient<ILiqueurRepository, LiqueurRepository>();
services.AddTransient<ILiquorRepository, LiquorRepository>();

services.AddTransient<IMeasurementRepository, MeasurementRepository>();
services.AddTransient<IMeasurementTypeRepository, MeasurementTypeRepository>();
services.AddTransient<IMixerRepository, MixerRepository>();
services.AddTransient<ISyrupRepository, SyrupRepository>();

services.AddGraphQLServer()
    .AddQueryType<QueryType>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGraphQL();
app.MapControllers();

app.Run();
    