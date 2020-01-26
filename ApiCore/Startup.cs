using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDI();//  DI
            services.AddDBInfo(Configuration);//  DB
            services.AddJwtAuth(Configuration);//  JWT
            services.AddAutoMapper(typeof(Startup));//  automapper

            services.AddLocalSwagger();// config swagger

            services.AddControllers();
        }

        #endregion

        #region Configure

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            #region Swagger Config

            app.UseSwagger();
            app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Description");
                    c.OAuthClientId("client-id");
                    c.OAuthClientSecret("client-secret");
                    c.OAuthRealm("client-realm");
                    c.OAuthAppName("OAuth-app");
                    c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
                }
            );

            #endregion

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #endregion
    }
}
