using CommGate.Core.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CommGate.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDBContext context, IServiceProvider services)
        {
            // Get a logger
            var logger = services.GetRequiredService<ILogger<DbInitializer>>();
            
           
            context.Database.EnsureCreated();


            if (context.Roles.Any())
            {
                logger.LogInformation("Roles were already seeded");

            }
            else
            {
                logger.LogInformation("Start seeding the Roles .");

                AddRoles(context);

                logger.LogInformation("Finished seeding Roles");
            }
            static void AddRoles(ApplicationDBContext context)
            {

                context.Roles.Add(new Role
                {

                    Name = "SystemUser"
                });

                context.SaveChanges();

                context.Roles.Add(new Role
                {

                    Name = "CompanyAdmin"
                });
                context.SaveChanges();

                context.Roles.Add(new Role
                {

                    Name = "CompanyUser"
                });
                context.SaveChanges();
              
            }            
        }
    }
}