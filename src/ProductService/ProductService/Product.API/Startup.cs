using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.API.Infrastructure.BackgroundTasks.Options;
using Product.API.Infrastructure.BackgroundTasks.Tasks;
using Product.API.Infrastructure.HealthCheck;
using Product.Domain.Extensions.DependencyInjection;
using System;

namespace Product.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Register Dependencies
            services.RegisterProductDomain();

            // Import Options for background services from appSettings.json
            services.Configure<PollingTaskOptions>(Configuration.GetSection("PollingTaskOptions"));
            // Start background service.
            services.AddHostedService<PollingTask>();

            // Register the Swagger services
            services.AddSwaggerDocument();

            // Register Health Checks
            services.AddHealthChecks()
                .AddUrlGroup(new Uri("https://google.com"),"Google - Works")
                .AddUrlGroup(new Uri("https://IDontwork.com"), "Dummy - Fails");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Register the Swagger generator and the Swagger UI middlewares
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Create Health Checks Endpoint.
            // Default
            app.UseHealthChecks("/health");
            // Custom Response
            app.UseHealthChecks("/healthDetails", new HCOptions());

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
