using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend;
using BigScreen.Frontend.Client;
using BigScreen.Frontend.Client.Constants;
using BigScreen.Frontend.Client.Handlers;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Core.Helpers;
using BigScreen.Frontend.Pages.Search.ViewModel;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Http Clients
builder.Services.AddHttpClient(TmdbClientConstants.ClientName,
    client => client.BaseAddress = new Uri(TmdbClientConstants.BaseAddress));

// Helpers
builder.Services.AddSingleton<KeyVaultHelper>();


// TmdbClients
builder.Services.AddScoped<TmdbClient<MovieDto>>();
builder.Services.AddScoped<TmdbClient<SearchPageResultsDto>>();

// Handlers
builder.Services.AddScoped<IMovieHandler, MovieHandler>();
builder.Services.AddScoped<ISearchPageResultsHandler, SearchPageResultsHandler>();

// ViewModels
builder.Services.AddScoped<ISearchViewModel, SearchViewModel>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();