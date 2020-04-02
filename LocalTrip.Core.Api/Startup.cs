using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation;
using LocalTrip.Core.Api.Configurations;
using LocalTrip.Travel.Project.Application.Behaviors;
using LocalTrip.Travel.Project.Infra.Data.Context.MySql;
using LocalTrip.Travel.Project.Infra.Data.Interfaces;
using LocalTrip.Travel.Project.Infra.Data.Repository;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddDataProtection().DisableAutomaticKeyGeneration();
            
            AddApplicationServices(services);
            
              var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                    Configuration.GetSection("TokenConfigurations"))
                .Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);
            
            // Jwt
            
            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;
              
                paramsValidation.ValidateIssuerSigningKey = true;
              
                paramsValidation.ValidateLifetime = true;
               
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });
            
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            // ===== Add our DbContext ========
            var con = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // ===== Add Identity ========
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<MySqlContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.User.RequireUniqueEmail = true;
            });
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Local Trip's .Lab"
                    ,Description = "Localtrip.Lab API REST criada com o ASP.NET Core"
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
            //services.AddDbContext<MySqlContext>(o => o.UseMySQL(Configuration.GetSection("ConnectionStrings:Connection").Value));
            
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
            services.AddScoped<ITripRepository, TripRepository>();
            services.AddScoped<IDestinationRepository, DestinationRepository>();
            
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