using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Swashbuckle.AspNetCore.Swagger;

namespace Demo.ApiGateWay
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot(Configuration);

            // Swagger
            services.AddMvc();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc($"{Configuration["Swagger:DocName"]}", new Info
                {
                    Title = Configuration["Swagger:Title"],
                    Version = Configuration["Swagger:Version"]
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // get from service discovery later
            var apiList = new List<string>()
            {
                "clientservice",
                "clientservice1",
                "productservice"
            };
            app.UseMvc()
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    apiList.ForEach(apiItem =>
                    {
                        options.SwaggerEndpoint($"/doc/{apiItem}/swagger.json", apiItem);
                    });
                });

            app.UseOcelot().Wait();
        }
    }
}
