using Meetup.BLL.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MeetupAPI.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IConfiguration configuration)
        {
            if (!string.IsNullOrEmpty(context.Request.Cookies["jwt"]))
            {
                var token = context.Request.Cookies["jwt"].ToString().Split(' ').Last();

                var userEmail = ValidateToken(token, configuration);

                if (userEmail != null)
                {
                    CancellationToken ct = new CancellationToken();

                    context.Items["User"] = await userService.GetUserByEmail(userEmail, ct);
                }
            }

            await _next(context);
        }

        public string ValidateToken(string token, IConfiguration configuration)
        {
            if (token == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,

                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userEmail = jwtToken.Claims.First(x => x.Type == "email").Value;

                return userEmail;
            }
            catch
            {
                return null;
            }
        }
    }
}
