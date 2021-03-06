using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace myhub
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();

            services.AddCors(options =>
           {
               options.AddPolicy("AllowSpecificOrigins",
                     builder =>
                     {
                         // builder.AllowAnyOrigin();
                         builder.WithOrigins("http://localhost:8081").WithOrigins("http://localhost:8080")
                        .AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                     });
           }
           );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowSpecificOrigins");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<myhub.Hubs.CommunicationHub>("myHub");

                endpoints.MapGet("/", async context =>
                      {
                          await context.Response.WriteAsync("Hello World!");
                      });
            });
        }
    }
}
