using BlazorApp1.Client;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Repository;
using Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configure HttpClient to use the base address of the Blazor WebAssembly application
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register services
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Register your services
builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<RoomService>();
builder.Services.AddScoped<PatientTherapyService>();
builder.Services.AddScoped<PatientReservationService>();

await builder.Build().RunAsync();
