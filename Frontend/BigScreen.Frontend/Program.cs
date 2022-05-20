using BigScreen.Frontend;
using BigScreen.Frontend.Client;
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
builder.Services.AddScoped<IClient<MovieDto>, TmdbClient<MovieDto>>();
builder.Services.AddScoped<IClient<OurMovieDto>, BaseODataClient<OurMovieDto>>();

builder.Services.AddScoped(_ => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
builder.Services.AddMudServices();

await builder.Build().RunAsync();

//todo this is also conceptual
var oDataClient = builder.Build().Services.GetService<IClient<OurMovieDto>>() as BaseODataClient<OurMovieDto>;
var baseODataClient = builder.Build().Services.GetService<BaseODataClient<OurMovieDto>>();


//todo take a guess
public class MovieDto : TmdbDto
{
}

//todo and again
public class OurMovieDto : BaseDto
{
}