using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OfficeRetro.Api;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);
startup.ConfigureSwagger(builder.Services);
startup.ConfigureCors(builder.Services);

builder.Services.AddAuthentication(builder =>
{
    builder.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    builder.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(option =>
{
    option.SaveToken = true;
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("IamsoverylongestIamsoverylongestIamsoverylongestIamsoverylongestIamsoverylongestIamsoverylongestIamsoverylongestIamsoverylongest")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

startup.Configure(app, app.Environment);

app.MapControllers();

app.Run();
