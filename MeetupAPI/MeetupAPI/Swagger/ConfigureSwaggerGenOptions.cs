using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MeetupAPI.Swagger
{
    public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions options)
        {
            options.AddSecurityDefinition("OAuth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,

                Flows = new OpenApiOAuthFlows
                {
                    Password = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri("http://localhost:8774"),
                        TokenUrl = new Uri("http://localhost:8774"),
                        Scopes = new Dictionary<string, string>
                        {
                            //{ _settings.Security.Jwt.Audience , "Balea Server HTTP Api" }
                        }
                    }
                },

                Description = "Balea Server OpenId Security Scheme"
            });
        }
    }
}