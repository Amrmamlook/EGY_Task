using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Task_Test.Options.Config
{
    public static class SwaggerConfiguration
    {
        public static void Configure(this SwaggerGenOptions options)
        {
            options.AddSecurityDefinition("JwtBearerDefinition", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Description = "Enter your Auth JWT Access Token",
                Scheme = "Bearer",
                Type = SecuritySchemeType.Http
            });


            //For attaching the auth header on each endpoint request
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {

                        Reference = new OpenApiReference
                        {
                            Id = "JwtBearerDefinition",
                            Type = ReferenceType.SecurityScheme
                        }
                    },
                    new List<string>()
                }
            });
        }
    }
}
