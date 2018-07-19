using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ResumeAPI.Models;


namespace ResumeAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var seeder = services.GetRequiredService<DataSeeder>();
                    var context = services.GetRequiredService<DataContext>();
                    context.Database.EnsureCreated();
                    seeder.SeedData();
                }
                catch (Exception e)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e, "An error occurred while creating the database.");
                }
            }

            host.Run();
        }


        public static IWebHost BuildWebHost(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .UseStartup<ResumeAPI.Startup>()
        .Build();


    }
}






