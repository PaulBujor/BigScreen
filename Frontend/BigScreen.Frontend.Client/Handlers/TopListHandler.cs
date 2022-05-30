using BigScreen.Core.Models.BigScreen;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Client.Security;

namespace BigScreen.Frontend.Client.Handlers;

public class TopListHandler : ITopListHandler
{
    private static readonly CachedUserDto CachedUserDto1 = new()
    {
        Id = "1",
        Username = "Username1"
    };

    private readonly List<TopListDto> _dummyTopLists = new()
    {
        new TopListDto
        {
            Id = "1",
            Owner = CachedUserDto1,
            Title = "My Toplist 1 -- has movies",
            Movies = new List<CachedMovieDto>
            {
                new()
                {
                    Id = "movie-550",
                    Name = "Fist pump"
                },
                new()
                {
                    Id = "movie-551",
                    Name = "Fist pump"
                },
                new()
                {
                    Id = "tv-550",
                    Name = "asdf"
                },
                new()
                {
                    Id = "tv-551",
                    Name = "asdfasd"
                }
            }
        },
        new TopListDto
        {
            Id = "2",
            Owner = CachedUserDto1,
            Title = "My Toplist 2"
        },
        new TopListDto
        {
            Id = "3",
            Owner = CachedUserDto1,
            Title = "My Toplist 3"
        },
        new TopListDto
        {
            Id = "4",
            Owner = CachedUserDto1,
            Title = "My Toplist 4"
        }
    };

    private readonly UserState _userState;

    public TopListHandler(UserState userState)
    {
        _userState = userState;
    }

    public async Task<TopListDto?> GetTopListAsync(string topListId)
    {
        return await Task.FromResult(_dummyTopLists.FirstOrDefault(t => t.Id == topListId) ?? null);
    }

    public async Task<TopListDto> CreateTopListAsync(string topListName)
    {
        if (_userState.User == null) throw new InvalidOperationException();

        var topList = new TopListDto
        {
            Id = Guid.NewGuid().ToString(), //todo remove and let server do it
            Title = topListName,
            Owner = _userState.User.GetCachedVersion(),
            Movies = new List<CachedMovieDto>()
        };

        _dummyTopLists.Add(topList);
        if (_userState.User.SavedTopLists == null) _userState.User.SavedTopLists = new HashSet<CachedTopListDto>();
        _userState.User.SavedTopLists.Add(topList.GetCachedVersion());
        _userState.User = _userState.User; //dumb but sends the update signal

        return await Task.FromResult(topList);
    }

    public async Task<TopListDto> AddMovieToTopListAsync(string topListId, CachedMovieDto movieDto)
    {
        var topList = _dummyTopLists.FirstOrDefault(t => t.Id == topListId);
        if (topList == null) throw new InvalidOperationException();

        if (topList.Movies == null) topList.Movies = new List<CachedMovieDto>();

        if (!topList.Movies.Contains(movieDto))
            topList.Movies.Add(movieDto);
        //todo better

        return await Task.FromResult(topList);
    }

    public async Task<TopListDto> RemoveMovieFromTopListAsync(string topListId, string movieId)
    {
        var topList = _dummyTopLists.FirstOrDefault(t => t.Id == topListId);
        if (topList == null) throw new InvalidOperationException();

        var idDto = new CachedMovieDto
        {
            Id = movieId
        };

        topList.Movies?.Remove(idDto);
        //todo better

        return await Task.FromResult(topList);
    }

    public async Task DeleteTopListAsync(string topListId)
    {
        var topList = _dummyTopLists.FirstOrDefault(t => t.Id == topListId);
        if (topList != null)
        {
            _dummyTopLists.Remove(topList);
            _userState.User?.SavedTopLists?.Remove(topList.GetCachedVersion());
            _userState.User = _userState.User;
        }

        await Task.CompletedTask;
    }
}