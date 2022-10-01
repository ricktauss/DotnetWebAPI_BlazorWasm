global using SharedLibrary.MongoDB.Models;
global using SharedLibrary.DTOs;
global using BlazorApiBackend.Services;
global using Microsoft.AspNetCore.Mvc;

using BlazorApiBackend.Repositories;
using WebApiBackend.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
//builder.Services.AddSingleton<IPersonRepository, MockPersonRepository>();
builder.Services.AddSingleton<IPersonRepository, MongoDbPersonRepository>();
builder.Services.AddTransient<IPersonService, PersonService>();

builder.Services.Configure<PersonStoreDatabaseSettings>(builder.Configuration.GetSection("PersonStoreDatabase"));

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseCors(
    options => options.WithOrigins("https://localhost:7275").AllowAnyMethod()
);

app.UseAuthorization();

app.MapControllers();


app.Run();