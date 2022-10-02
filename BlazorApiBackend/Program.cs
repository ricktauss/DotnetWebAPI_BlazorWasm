global using SharedLibrary.MongoDB.Models;
global using SharedLibrary.DTOs;
global using BlazorApiBackend.Services;
global using Microsoft.AspNetCore.Mvc;

using BlazorApiBackend.Repositories;
using WebApiBackend.Repositories;
using WebApiBackend;
using NLog;
using NLog.Web;
using System;


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
    builder.Services.AddSwaggerGen();

    builder.Services.ConfigureCors();


    var app = builder.Build();


    // Configure the HTTP request pipeline.

    //if (app.Environment.IsDevelopment())
    //{
    app.UseSwagger();
    app.UseSwaggerUI();
    //}

    //integrate https://code-maze.com/global-error-handling-aspnetcore/
    app.UseHttpsRedirection();
    app.UseCors("CorsPolicy");
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