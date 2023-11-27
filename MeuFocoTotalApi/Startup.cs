using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MeuFocoTotalApi.Common;
using MeuFocoTotalApi.Ioc;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;
using System.Diagnostics;
using System.ComponentModel;

namespace HexagonProGraneisRecepcaoApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Base.TIPOBANCO = Configuration["Settings:TIPOBANCO"];
            Base.PATHBASE = Configuration["Settings:PathBase"];
            Base.BACKGROUNDSTOCKCONTROL = Configuration["Settings:BACKGROUND-STOCK-CONTROL"];
            switch (Base.TIPOBANCO)
            {
                case "SQL":
                    Base.STRINGCONEXAO = Configuration["ConnectionStrings:SQL"];
                    break;
                case "ORACLE":
                    Base.STRINGCONEXAO = Configuration["ConnectionStrings:Oracle"];
                    Base.STRINGCONEXAOLOGIN = Configuration["ConnectionStrings:LoginOracle"];
                    break;
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsAllowAll",
                builder => builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            });

            services.AddControllers();
            services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Meu Foco Total",
                    Version = "v1",
                    Description = "Api do app Meu Foco Total",
                    Contact = new OpenApiContact
                    {
                        Name = "",
                        Email = ""
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Meu Foco Total",
                    }

                });
                // To Enable authorization using Swagger (JWT)
            });


            RepositoryInjector.RegisterRepositories(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UsePathBase(Base.PATHBASE);
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "text/html";
                    IExceptionHandlerPathFeature exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    await context.Response.WriteAsync($"Internal Error \nPath : {exceptionHandlerPathFeature.Path} \nError: {exceptionHandlerPathFeature.Error.Message} ");

                });
            });

            var supportedCultures = new[] {
                new CultureInfo("en-US"),
                new CultureInfo("en-AU"),
                new CultureInfo("en-GB"),
                new CultureInfo("en"),
                new CultureInfo("es-ES"),
                new CultureInfo("es-MX"),
                new CultureInfo("es"),
                new CultureInfo("fr-FR"),
                new CultureInfo("fr"),
            };



            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("CorsAllowAll");

            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("v1/swagger.json", "Meu Foco Total API");
                option.RoutePrefix = "swagger";
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
