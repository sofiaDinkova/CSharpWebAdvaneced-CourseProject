namespace Blasco.Web.Infrastructure.Extentions
{
    using System.Reflection;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    using Data.Models;
    using static Common.GeneralApplicationConstants;

    public static class WebApplicationBuilderExtention
    {
        public static void AddApplicationServices(this IServiceCollection services, Type serviceType)
        {
            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);

            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("Invalid service type provided!");
            }

            Type[] serviceTypes = serviceAssembly.GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();

            foreach (Type st in serviceTypes)
            {
                Type? interfaceType = st.GetInterface($"I{st.Name}");
                if (interfaceType == null)
                {
                    throw new InvalidOperationException($"No Interface is provided for the service with name: {st.Name}");
                }

                services.AddScoped(interfaceType, st);
            }
        }
   
        public static IApplicationBuilder CreateRolesAdminCreatorAndCustomer(this IApplicationBuilder app)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            UserManager<ApplicationUser> creatorManagaer = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole<Guid>> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                IdentityRole<Guid> role;

                if (!roleManager.Roles.Any(r => r.Name == AdminRoleName))
                {
                    role = new IdentityRole<Guid>(AdminRoleName);
                    await roleManager.CreateAsync(role);
                }

                if (!await roleManager.RoleExistsAsync(CreatorRoleName))
                {
                    role = new IdentityRole<Guid>(CreatorRoleName);
                    await roleManager.CreateAsync(role);
                }

                if (!await roleManager.RoleExistsAsync(CustomerRoleName))
                {
                    role = new IdentityRole<Guid>(CustomerRoleName);
                    await roleManager.CreateAsync(role);
                }
            })
                .GetAwaiter()
                .GetResult();

            return app;
        }

    }
}
