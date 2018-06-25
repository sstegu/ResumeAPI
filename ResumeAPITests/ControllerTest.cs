using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using ResumeAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace ResumeAPITests
{
    public abstract class ControllerTest
    {
        protected TestServer _server;
        protected HttpClient _client;

        public ControllerTest()
        {
            var confBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("unitTestSettings.json");//had to modify project config to copy this file to build output

            IConfiguration config = confBuilder.Build();

            var builder = new WebHostBuilder()
                .UseConfiguration(config)
                .UseEnvironment("Development")
                .UseStartup<ResumeAPITests.Startup>();

            _server = new TestServer(builder);

            _client = _server.CreateClient();

            DataSeeder seeder = _server.Host.Services.GetService(typeof(DataSeeder)) as DataSeeder;
            seeder.SeedData();

        }
    }
}
