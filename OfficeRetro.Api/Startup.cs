using OfficeRetro.Application;
using OfficeRetro.Contracts;
using OfficeRetro.Infrastructure;
using OfficeRetro.Shared;

namespace OfficeRetro.Api;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddShared()
            .AddInfrastructure(Configuration)
            .AddApplication()
            .AddPresentation()
            .AddContracts();
    }

    public void ConfigureSwagger(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        //services.AddSwaggerGen(option =>
        //{
        //    option.OperationFilter<SecurityRequirementsOperationFilter>(true, "Bearer");
        //    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        //    {
        //        Description = "Standard Authorization header using the Bearer scheme (JWT). Example: \"bearer {token}\"",
        //        Name = "Authorization",
        //        In = ParameterLocation.Header,
        //        Type = SecuritySchemeType.ApiKey,
        //        Scheme = "Bearer"
        //    });
        //    option.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
        //});
        services.AddSwaggerGen();
        //services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
    }

    public void ConfigureCors(IServiceCollection services)
    {
        services.AddCors(option =>
        {
            option.AddPolicy("ClientNetwork", policyBuilder =>
            {
                policyBuilder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            //app.UseSwaggerUI(option =>
            //{
            //    option.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            //    option.RoutePrefix = string.Empty;
            //});
            app.UseSwaggerUI();
        }

        app.UseExceptionHandler("/error");

        app.UseHttpsRedirection();

        app.UseCors("ClientNetwork");

        app.UseAuthentication();
        app.UseAuthorization();
    }
}
