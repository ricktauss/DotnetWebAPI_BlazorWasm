//Global usings
global using Microsoft.AspNetCore.Components;
global using SharedLibrary.MongoDB.Models;
global using Fluxor;
global using Fluxor.Blazor.Web.Components;
global using BlazorDemoApp.Store.Persons;
global using BlazorDemoApp.Store.Counter;

using BlazorDemoApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddFluxor(options =>
{
    options.ScanAssemblies(typeof(Program).Assembly);

#if DEBUG
    options.UseReduxDevTools(); //optional for Chrome plugin
#endif
});//Fluxor

await builder.Build().RunAsync();
