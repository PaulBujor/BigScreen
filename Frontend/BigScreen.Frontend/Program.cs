using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend;
using BigScreen.Frontend.Client;
using BigScreen.Frontend.Client.Constants;
using BigScreen.Frontend.Client.Handlers;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Components.Card.ViewModel;
using BigScreen.Frontend.Components.Discussion.ViewModel;
using BigScreen.Frontend.Components.GeneralPageLayout.ViewModel;
using BigScreen.Frontend.Components.MediaDetailsPageLayout.ViewModel;
using BigScreen.Frontend.Components.ScoreCard.ViewModel;
using BigScreen.Frontend.Components.SearchResult.ViewModel;
using BigScreen.Frontend.Core.Enums;
using BigScreen.Frontend.Core.Helpers;
using BigScreen.Frontend.Pages.DetailsPages.Movie.ViewModel;
using BigScreen.Frontend.Pages.GeneralPages.Movies.ViewModel;
using BigScreen.Frontend.Pages.GeneralPages.People.ViewModel;
using BigScreen.Frontend.Pages.GeneralPages.TvShows.ViewModel;
using BigScreen.Frontend.Pages.Home.ViewModel;
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
builder.Services.AddScoped<TmdbClient<MoviesSearchResultsDto>>();
builder.Services.AddScoped<TmdbClient<TvShowsSearchResultsDto>>();
builder.Services.AddScoped<TmdbClient<PeopleSearchResultsDto>>();

// Handlers
builder.Services.AddScoped<IMovieHandler, MovieHandler>();
builder.Services.AddScoped<ISearchPageResultsHandler, SearchPageResultsHandler>();
builder.Services
    .AddScoped<IGeneralSearchPageResultsHandler<MoviesSearchResultsDto>,
        GeneralSearchPageResultsHandler<MoviesSearchResultsDto>>();
builder.Services
    .AddScoped<IGeneralSearchPageResultsHandler<PeopleSearchResultsDto>,
        GeneralSearchPageResultsHandler<PeopleSearchResultsDto>>();
builder.Services
    .AddScoped<IGeneralSearchPageResultsHandler<TvShowsSearchResultsDto>,
        GeneralSearchPageResultsHandler<TvShowsSearchResultsDto>>();
builder.Services
    .AddScoped<IDetailsPageHandler<MovieDto>,
        DetailsPageHandler<MovieDto>>();

// ViewModels
builder.Services.AddTransient<IHomeViewModel, HomeViewModel>();
builder.Services.AddTransient<ISearchViewModel, SearchViewModel>();
builder.Services.AddTransient<IMoviesViewModel, MoviesViewModel>();
builder.Services.AddTransient<IPeopleViewModel, PeopleViewModel>();
builder.Services.AddTransient<ITvShowsViewModel, TvShowsViewModel>();
builder.Services.AddTransient<ISearchResultViewModel, SearchResultViewModel>();
builder.Services.AddTransient<ICardViewModel, CardViewModel>();
builder.Services.AddTransient<IScoreCardViewModel, ScoreCardViewModel>();
builder.Services.AddTransient<IMovieViewModel, MovieViewModel>();
builder.Services.AddTransient<IMediaDetailsPageLayoutViewModel, MediaDetailsPageLayoutViewModel>();
builder.Services.AddTransient<IGeneralPageLayoutViewModel<SortFilter>, GeneralPageLayoutViewModel<SortFilter>>();
builder.Services.AddTransient<IGeneralPageLayoutViewModel<SearchFilter>, GeneralPageLayoutViewModel<SearchFilter>>();
builder.Services.AddSingleton<IDiscussionViewModel, DiscussionViewModel>();

// MudBlazor
builder.Services.AddMudServices();

// Authentication
builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
    options.ProviderOptions.LoginMode = "redirect";
});

await builder.Build().RunAsync();