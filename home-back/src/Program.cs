using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using src;
using src.GraphQL;
using src.Repositories;
using src.Repositories.Interfaces;


namespace src
{
    public class Startup
    {
       
        public static  void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BarContext>(options =>
                options.UseNpgsql(connectionString)
            );
            
            services.AddDbContext<BarContext>(options =>
                options.UseNpgsql(connectionString)
            );

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            
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

            services.AddSwaggerGen (c =>
            {
                c.ResolveConflictingActions (apiDescriptions => apiDescriptions.First ());
            });

            services
                .AddGraphQLServer()
                .AddQueryType<QueryType>()
                .AddMutationType<MutationType>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDatabaseDeveloperPageExceptionFilter();

        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            // For Heroku connectivity 
            // This routes the https calls from heroku to the asp application
            var forwardedHeadersOptions = new ForwardedHeadersOptions {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            };
            forwardedHeadersOptions.KnownNetworks.Clear();
            forwardedHeadersOptions.KnownProxies.Clear();
            app.UseForwardedHeaders(forwardedHeadersOptions);

            app.UseRouting();

            // // global cors policy
            app.UseCors();
    
            var rewriteOptions = new RewriteOptions ().AddRedirectToHttps(308);
            app.UseRewriter(rewriteOptions);
            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}