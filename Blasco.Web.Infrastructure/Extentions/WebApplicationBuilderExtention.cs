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
        public static IApplicationBuilder createCreatorRole(this IApplicationBuilder app, string email)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            UserManager<ApplicationUser> creatorManagaer = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole<Guid>> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(CreatorRoleName))
                {
                    return;
                }
                if (await roleManager.RoleExistsAsync(CustomerRoleName))
                {
                    return;
                }

                IdentityRole<Guid> roleCustomer = new IdentityRole<Guid>(CustomerRoleName);

                await roleManager.CreateAsync(roleCustomer);

                IdentityRole<Guid> roleCreator = new IdentityRole<Guid>(CreatorRoleName);

                await roleManager.CreateAsync(roleCreator);

                ApplicationUser creatorUser = await creatorManagaer.FindByEmailAsync(email);

                await creatorManagaer.AddToRoleAsync(creatorUser, AdminRoleName);

            })
                .GetAwaiter()
                .GetResult();

            return app;
        }
        public static IApplicationBuilder SeedAdministrator(this IApplicationBuilder app, string email)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            UserManager<ApplicationUser> creatorManagaer = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole<Guid>> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    return;
                }

                IdentityRole<Guid> role = new IdentityRole<Guid>(AdminRoleName);

                await roleManager.CreateAsync(role);

                ApplicationUser adminUser = await creatorManagaer.FindByEmailAsync(email);

                await creatorManagaer.AddToRoleAsync(adminUser, AdminRoleName);
            })
                .GetAwaiter()
                .GetResult();

            return app;
        }
    }
}
