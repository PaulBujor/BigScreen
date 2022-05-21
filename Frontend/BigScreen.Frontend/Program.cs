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

//todo this is conceptual
builder.Services.AddScoped<TmdbClient<MovieDto>>();
builder.Services.AddScoped<IMovieHandler, MovieHandler>();
// builder.Services.AddScoped<IClient<OurMovieDto>, BaseODataClient<OurMovieDto>>();
//builder.Services.AddHttpClient(TmdbClientConstants.ClientName,_ => _.BaseAddress = new Uri(new Uri(TmdbClientConstants.BaseAddress), new Uri(TmdbClientConstants.ApiVersion)));
builder.Services.AddHttpClient(TmdbClientConstants.ClientName,_ => _.BaseAddress = new Uri(TmdbClientConstants.BaseAddress));
builder.Services.AddMudServices();

await builder.Build().RunAsync();

//todo this is also conceptual
// var oDataClient = builder.Build().Services.GetService<IClient<OurMovieDto>>() as BaseODataClient<OurMovieDto>;
// var baseODataClient = builder.Build().Services.GetService<BaseODataClient<OurMovieDto>>();

