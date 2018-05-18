using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using TodoApi.Models;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace TodoApi
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
            services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            services.AddMvc();

            //Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "My API",
                    Version = "v1",
                    Description = "A simple example ASP.Net Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Mykola Antoniuk", Email = "mykolantoniuk@gmail.com", Url = "https://anicolays.com" },
                    License = new License { Name = "Use under LICX", Url = "https://example.com/license" }
                });
            
            // Set the comments path for the Swagger JSON and UI
           // var basePath = AppContext.BaseDirectory;
           // IFileProvider provider; provider.GetDirectoryContents
            //var xmlPath = Path.Combine(basePath, "TodoApi.xml");
            // if (!System.IO.File.Exists(xmlPath))
            // {
            //     System.IO.File.Create(xmlPath, 0, System.IO.FileOptions.WriteThrough);
            // } 
          //  c.IncludeXmlComments(@"C:\Users\Mykola\Desktop\TodoApi\bin\Debug\netcoreapp2.0\TodoApi.xml");
            });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoit.
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
