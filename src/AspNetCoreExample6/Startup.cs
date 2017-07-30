using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AspNetCoreExample6.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using AspNetCoreExample6.Options;

namespace AspNetCoreExample6
{
    public class Startup
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public Startup(IHostingEnvironment env)
        {
            hostingEnvironment = env;
        }

        public void ConfigureSettings(IServiceCollection services)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("alertThresholds.json")
                .AddJsonFile($"alertThresholds{hostingEnvironment.EnvironmentName}.json", optional: true);
            var config = configBuilder.Build();

            services.Configure<ThresholdOptions>(config);
            services.AddOptions();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureSettings(services);
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<ISensorDataService, SensorDataService>();
            services.AddSingleton<IViewModelService, ViewModelService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            var logger = loggerFactory.CreateLogger("info");

            if (hostingEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseStatusCodePages();
            //app.UseStatusCodePagesWithRedirects("~/error/code{0}");
            app.UseMvcWithDefaultRoute();
            //app.UseMvc(routes => {
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller}/{action}/{id?}",
            //        defaults: new { controller = "Home", Index = "Index" }
            //    );
            //});

            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("before app.run");
            //    await next();
            //    logger.LogInformation("after app.run");
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World2!");
            //    logger.LogInformation("app.run");
            //});
        }
    }
}
