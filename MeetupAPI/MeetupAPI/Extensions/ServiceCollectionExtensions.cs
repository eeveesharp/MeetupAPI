using MeetupAPI.Swagger;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MeetupAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My Meetup API",
                    Version = "v1"
                });

                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    In = ParameterLocation.Header,
                //    Description = "Please insert JWT with Bearer into field",
                //    Name = "Authorization",
                //    Type = SecuritySchemeType.ApiKey
                //});

                //c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                //{
                //    new OpenApiSecurityScheme
                //    {
                //        Reference = new OpenApiReference
                //        {
                //            Type = ReferenceType.SecurityScheme,
                //            Id = "Bearer"
                //        }
                //    },

                //    new string[] { }
                //    }
                //});
            });
        }
    }
}