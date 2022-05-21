using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend;
using BigScreen.Frontend.Client;
using BigScreen.Frontend.Client.Handlers;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Core;
using BigScreen.SDK.Client;
using BigScreen.SDK.Client.Abstractions;
using BigScreen.SDK.WebAPI.Core;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//TmdbClients
builder.Services.AddScoped<TmdbClient<MovieDto>>();

// Handlers
builder.Services.AddScoped<IMovieHandler, MovieHandler>();

//Http Clients
builder.Services.AddHttpClient(TmdbClientConstants.ClientName,_ => _.BaseAddress = new Uri(TmdbClientConstants.BaseAddress));
builder.Services.AddMudServices();

await builder.Build().RunAsync();

