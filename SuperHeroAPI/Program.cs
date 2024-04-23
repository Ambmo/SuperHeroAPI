using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SuperheroAPI.DAL;
using SuperheroAPI.DAL.SuperheroAPI.DAL;
using SuperheroAPI.Models;
using SuperheroAPI.Services;
using SuperheroAPI.Services.Interfaces;
using SuperHeroAPI.Models;

namespace SuperheroAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureServices(builder.Services);

            var app = builder.Build();

            Configure(app, app.Environment);
            
            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("DefaultConnection"));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IRepository<Favorite>, Repository<Favorite>>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFavoriteService, FavoriteService>();

            services.AddControllers();
            services.AddRazorPages();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Superhero API", Version = "v1" });
                var filePath = Path.Combine(AppContext.BaseDirectory, "SuperheroAPI.xml");
                c.IncludeXmlComments(filePath);
            });
            services.AddHttpClient<SuperheroService>();
            //services.AddAuthentication("Bearer")
            //.AddJwtBearer("Bearer", options =>
            //{
            //    options.Authority = "https://localhost:5001";
            //    options.RequireHttpsMetadata = false;
            //    options.Audience = "api1";
            //});

            //services.AddAuthorization();
        }
        private static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios.
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Superhero API");
                c.RoutePrefix = "docs";
            });

            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    context.Response.Redirect("/docs");
                    return;
                }

                await next();
            });



            // Migrate the database on startup
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var dbContext = serviceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.Migrate();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });

        }
    }
}
