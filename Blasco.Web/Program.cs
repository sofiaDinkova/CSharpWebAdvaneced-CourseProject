namespace Blasco.Web
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using Data;
    using Data.Models;
    using Services.Data.Interfaces;
    using Infrastructure.Extentions;
    using Infrastructure.ModelBinders;
    using Data.BlascoMongoDbFactory;
    using Data.BlascoMongoDbFactory.Interfaces;

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

            builder.Services
                .AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                });


            WebApplication app = builder.Build();

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

            app.UseEndpoints(config =>
            {
                config.MapControllerRoute(
                  name: "Admin",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                config.MapControllerRoute(
                    name: "ProtectingUrlRoute",
                    pattern: "/{controller}/{action}/{id}/{information}",
                    defaults: new { Controller = "Product", Action = "Details" });

                config.MapDefaultControllerRoute();

                config.MapRazorPages();
            });

            app.Run();
        }
    }
}