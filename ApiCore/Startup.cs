using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using AutoMapper;

using ApiCore.ConfigServices;

namespace ApiCore
{
    public class Startup
    {
        #region Properties

        public IConfiguration Configuration { get; }

        #endregion

        #region Construct

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region ConfigureServices

        // for local request
        //readonly string LocalhostOrigins = "_localhostOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDI();//  DI
            services.AddDBInfo(Configuration);//  DB
            services.AddJwtAuth(Configuration);//  JWT
            services.AddAutoMapper(typeof(Startup));   //  automapper (deprecated)

            // JUST DEVELOP MODE
            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //  config json result on mvc controllers
            services.AddMvc().AddJsonOptions(ConfigureJson);

            // config swagger
            services.AddSwagger();
        }

        //  just for configure json result 
        private void ConfigureJson(MvcJsonOptions obj)
        {
            obj.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }

        #endregion

        #region Configure

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                #region Swagger Config

                //app.UseSwagger(); // default config
                //app.UseSwagger(
                ////    options =>
                ////{
                ////    options.RouteTemplate = "swagger/{documentName}/swagger.json";
                ////}
                //);
                //app.UseSwaggerUI(c =>
                //    {
                //        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Description");
                //        //c.InjectStylesheet("/swagger/theme-material.css");
                //        c.RoutePrefix = "api-docs/swagger";
                //    }
                //);

                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("swagger/v1/swagger.json", "My API V1");
                    c.InjectStylesheet("swagger");
                });

                #endregion

                #region Cors Config

                app.UseCors(x =>
                {
                    x.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });

                #endregion
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvc();

        }

        #endregion
    }
}
