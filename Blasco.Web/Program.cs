namespace Blasco.Web
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using Services.Data.Interfaces;
    using Infrastructure.Extentions;
    using Infrastructure.ModelBinders;

    using static Common.GeneralApplicationConstants;
    using Blasco.Data.Configurations.Seed;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using MongoDB.Driver;
    using Blasco.Data.BlascoMongoDbFactory;
    using Microsoft.Extensions.DependencyInjection;
    using Blasco.Data.BlascoMongoDbFactory.Interfaces;
    using Blasco.Web.ViewModels.Home;
    using System.Reflection;

    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IMongoDbFactory>(new MongoDbFactory());

            MongoDbFactory mongoDbFactory = new MongoDbFactory();
            mongoDbFactory.SeedImage();

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<BlascoDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");

                options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                options.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
            })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<BlascoDbContext>();

            builder.Services.AddApplicationServices(typeof(IProjectService));

            builder.Services.AddMemoryCache();
            builder.Services.AddResponseCaching();

            builder.Services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LogoutPath = "/Creator/Login";
                cfg.AccessDeniedPath = "/Home/Error/401";
            });

            ////string mongoConnectionString = builder.Configuration.GetConnectionString("mongodb://localhost:27017") ?? throw new InvalidOperationException("Connection string 'MongoDBConnection' not found.");
            //MongoClientSettings mongoClientSettings = MongoClientSettings.FromConnectionString("mongodb://localhost:27017");
            //IMongoClient mongoClient = new MongoClient(mongoClientSettings);
            //IMongoDatabase mongoDatabase = mongoClient.GetDatabase("blasco");

            //builder.Services.AddSingleton(mongoClient);
            //builder.Services.AddSingleton(mongoDatabase);


            builder.Services
                .AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                });

            //BlascoMongoExperimental mongoDb = new BlascoMongoExperimental();
            //mongoDb.ListDatabases();



            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error/500");
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseResponseCaching();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.EnableOnlineUsersCheck();

            if (app.Environment.IsDevelopment())
            {
                //app.CreateRolesAdminCreatorAndCustomer();

                //var dataSeeder = new DataSeeder(app.Services);
                //dataSeeder.SeedData();

            }
            

            //app.MapControllerRoute(
            //name: "default",
            //pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseEndpoints(config =>
            {
                config.MapControllerRoute(
                  name: "Admin",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                //?????
                config.MapControllerRoute(
                    name: "ProtectingUrlRoute",
                    pattern: "{controller}/{action}/{id}/{information}",
                    defaults: new {Controller = "Category", Action = "Details"});

                config.MapDefaultControllerRoute();

                config.MapRazorPages();
            });

            app.Run();
        }
    }
}