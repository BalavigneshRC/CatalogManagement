using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CatalogManagement.Shared.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped(http => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress), });
builder.Services.AddScoped<ICategoryService, CategoryService>();

await builder.Build().RunAsync();
