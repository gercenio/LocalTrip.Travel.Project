using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation;
using LocalTrip.Travel.Project.Application.Behaviors;
using LocalTrip.Travel.Project.Infra.Data.Interfaces;
using LocalTrip.Travel.Project.Infra.Data.Repository;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;

namespace LocalTrip.Core.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            AddApplicationServices(services);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "HIEA.Lab Meu Einstein"
                    ,Description = "HIEA.Lab API REST criada com o ASP.NET Core"
                    ,Version = "0.0.1"
                });
                
                string caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao =
                    PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });
            services.AddOptions();
            
            services.AddSingleton<IConfiguration>(Configuration);
            
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app
            , IWebHostEnvironment env
            , ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "LOCAL TRIP - Version 0.0.1");
            });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
        
        private static string GetPathApplication()
        {
            return PlatformServices.Default.Application.ApplicationBasePath.ToString();
        }

        private static void AddApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IApiAccountRepository, ApiAccountRepository>();
            
            services.AddLogging();
            AddMediatr(services);
            
            
        }
        
        private static void AddMediatr(IServiceCollection services)
        {
            const string applicationAssemblyName = "LocalTrip.Travel.Project.Application.dll";

            AssemblyName an = AssemblyName.GetAssemblyName(GetPathApplication()+applicationAssemblyName);
            
            var assembly = System.Reflection.Assembly.Load(an); 
            
            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));

            services.AddMediatR(assembly);
        }
    }
}