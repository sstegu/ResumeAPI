﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ResumeAPI;
using ResumeAPI.Models;

namespace ResumeAPI
{
    public class Startup
    {
        private IHostingEnvironment _hostingEnvironment;

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(builder =>
            {
                builder.AddConfiguration(Configuration.GetSection("Logging"))
                    .AddAzureWebAppDiagnostics()
                    .AddConsole()
                    .AddDebug();

            });

            services.Configure<ApiSettings>(Configuration.GetSection("ApiSettings"));


            services.AddDbContext<DataContext>(options =>
            {
                options.UseInMemoryDatabase("cvdb");
                //options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddSingleton<IFileProvider>(_hostingEnvironment.ContentRootFileProvider);

            services.AddScoped<DataSeeder>();

            services.AddResponseCaching();

            services.AddMvc();

            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IFileProvider fileProvider, DataContext dataContext, IOptions<ApiSettings> settings)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //use cross origin resource sharing
            app.UseCors(policy => policy.WithOrigins(settings.Value.CorsOrigins).WithMethods("GET"));

            app.UseMvc();

        }

        private void OnShutdown(DataContext context)
        {

        }
    }
}
