global using SharedLibrary.MongoDB.Models;
global using SharedLibrary.DTOs;
global using BlazorApiBackend.Services;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Authentication.JwtBearer;

using BlazorApiBackend.Repositories;
using WebApiBackend.Repositories;
using NLog;
using NLog.Web;
using WebApiBackend.Extensions;
using Microsoft.OpenApi.Models;
using System.Reflection;

var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
logger.Debug("Application Starting Up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

    // Add services to the container.
    builder.Services.AddSingleton<IPersonRepository, MongoDbPersonRepository>();
    builder.Services.AddTransient<IPersonService, PersonService>();

    builder.Services.Configure<PersonStoreDatabaseSettings>(builder.Configuration.GetSection("PersonStoreDatabase"));

    builder.Services.AddAutoMapper(typeof(Program));
    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "DemoWebAPI",
            Description = "P&T InduSoft Demo Application",
            Contact = new OpenApiContact
            {
                Name = "P&T - Contact",
                Url = new Uri("https://www.pt-indusoft.at/contact/")
            },
        });

        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Description = "Bearer Authentication with JWT Token",
            Type = SecuritySchemeType.Http
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                new List<string>()
            }
        });
    });

    builder.Services.ConfigureCors();
    builder.Services.ConfigureJwt(builder.Configuration);

    builder.Services.AddAuthorization();


    var app = builder.Build();


    // Configure the HTTP request pipeline.

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }


    app.ConfigureExceptionHandler();
    app.UseHttpsRedirection();
    app.UseCors("CorsPolicy");
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    // NLog: catch setup errors
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    LogManager.Shutdown();
}