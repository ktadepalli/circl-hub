using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RecruitmentAPI.Repository;
using RecruitmentAPI.Models;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;

namespace RecruitmentAPI
{
    public class Startup
    {
        //public Startup(IWebHostEnvironment env)
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        private readonly string CoachingAppSpecificOrigins = "_coachingAppSpecificOrigins";
        //IConfigurationRoot _config;
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(CoachingAppSpecificOrigins,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();

                    });
            });
            // services.AddSingleton(_config);
            ///var sqlConnectionString = _config.GetConnectionString("mySQL");
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddDbContext<hris_tagContext>(ServiceLifetime.Scoped);
            services.AddScoped<IRecruitment, Recruitment>();
            services.AddScoped<IFactoryMaster, Department>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Registration API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors(CoachingAppSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            loggerFactory.AddLog4Net();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Registration API V1");
                c.RoutePrefix = string.Empty; //By default Swagger will appear for the local host path (If you ren directly local host path - Swagger will be appear)
            });

        }
    }
}