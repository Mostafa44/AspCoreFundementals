using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace OdeToFood
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeting, GreetingService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env,
                              IConfiguration configuration,
                              IGreeting greeting,
                              ILogger<Startup> logger
                              )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Use(next =>
            //{
            //    return async context =>
            //    {
            //        logger.LogInformation("Request Coming!!!");
            //        if (context.Request.Path.StartsWithSegments("/mym"))
            //        {
            //            await context.Response.WriteAsync("Hit!!!");
            //            logger.LogInformation("Request handled");
            //        }
            //        else
            //        {
            //            await next(context);
            //            logger.LogInformation("Request outgoing");
            //        }
            //    };
            //});
            //app.UseDefaultFiles();
             app.UseStaticFiles();
            //The Line below is an alterntaive to having "app.UseDefaultFiles(); app.UseStaticFiles();"
            app.UseMvcWithDefaultRoute();
            //app.UseFileServer();
            app.UseWelcomePage(new WelcomePageOptions() { Path="/wp"});
            app.Run(async (context) =>
            {
                // throw new Exception("Exception instead of greetings");
                //var greeting = config["Greeting"];
                // var message = greeting.GetMessageOfTheDay();
                var message = configuration["Greeting"];
                await context.Response.WriteAsync($"{message}: {env.EnvironmentName }");
            });
        }
    }
}
