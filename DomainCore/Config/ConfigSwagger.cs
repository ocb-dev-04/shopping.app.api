using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using Swashbuckle.AspNetCore.Swagger;

namespace DomainCore.Config
{
    public static class ConfigSwagger
    {
        public static void AddLocalSwaggerConf(this IServiceCollection services)
            => services.AddSwaggerGen(c =>
                    {
                        c.SwaggerDoc("v1", new Info
                        {
                            Version = "v1",
                            Title = "ToDo API",
                            Description = "A simple example ASP.NET Core Web API",
                            TermsOfService = "https://example.com/terms",
                            Contact = new Contact
                            {
                                Name = "Shayne Boyer",
                                Email = string.Empty,
                                Url = "https://twitter.com/spboyer",
                            },
                            License = new License
                            {
                                Name = "Use under LICX",
                                Url = "https://example.com/license",
                            }
                        });
                    });

        public static void AppLocalSwaggerConf(this IApplicationBuilder app)
        {
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Description")
            );
        }
        
        // end class
    }
}
