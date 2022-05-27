using BigScreen.Core.Models.BigScreen;
using Newtonsoft.Json;

namespace BigScreen.Frontend.Components.Discussion.ViewModel;

public class DiscussionViewModel : IDiscussionViewModel
{
    private static readonly CachedUserDto CachedUserDto1 = new()
    {
        Id = "1",
        Username = "Username1"
    };

    private static readonly CachedUserDto CachedUserDto2 = new()
    {
        Id = "2",
        Username = "Username2"
    };

    private static readonly CachedUserDto CachedUserDto3 = new()
    {
        Id = "3",
        Username = "Username3"
    };

    private readonly List<CommentDto> _dummyComments = new()
    {
        new CommentDto
        {
            Id = "1",
            ForMovie = "movie-550",
            Text = "1 Root Comment 1",
            ReplyTo = "-1",
            ByUser = CachedUserDto1
        },
        new CommentDto
        {
            Id = "2",
            ForMovie = "movie-550",
            Text = "2 Root Comment 2",
            ReplyTo = "-1",
            ByUser = CachedUserDto1
        },
        new CommentDto
        {
            Id = "3",
            ForMovie = "movie-550",
            Text = "3 Reply to 1",
            ReplyTo = "1",
            ByUser = CachedUserDto2
        },
        new CommentDto
        {
            Id = "4",
            ForMovie = "movie-550",
            Text = "4 Reply to 2",
            ReplyTo = "2",
            ByUser = CachedUserDto3
        },
        new CommentDto
        {
            Id = "5",
            ForMovie = "movie-550",
            Text = "5 Reply to 3",
            ReplyTo = "1",
            ByUser = CachedUserDto3
        },
        new CommentDto
        {
            Id = "6",
            ForMovie = "movie-550",
            Text = "6 Reply to 3",
            ReplyTo = "2",
            ByUser = CachedUserDto2
        },
        new CommentDto
        {
            Id = "7",
            ForMovie = "movie-551",
            Text = "Should not see 7",
            ByUser = CachedUserDto2
        },
        new CommentDto
        {
            Id = "8",
            ForMovie = "movie-551",
            Text = "Should not see 8",
            ByUser = CachedUserDto3
        }
    };

    private Action? _announceRootStateHasChanged;

    private List<CommentDto>? _comments;

    private string? _mediaId;

    public async Task InitializeAsync(string mediaId)
    {
        //todo replace with api call to cache comments
        if (mediaId != _mediaId)
        {
            _mediaId = mediaId;
            _comments = _dummyComments.Where(c => c.ForMovie == _mediaId).ToList();
        }

        await Task.CompletedTask;
    }

    public void AddListener(Action action)
    {
        _announceRootStateHasChanged += action;
    }

    public List<CommentDto> GetComments(string? replyTo = null)
    {
        return _comments?.Where(c => c.ReplyTo == replyTo).ToList() ?? new List<CommentDto>();
    }

    public async Task PostCommentAsync(CommentDto comment)
    {
        _comments?.Add(comment);
        _dummyComments.Add(comment);
        Console.WriteLine(JsonConvert.SerializeObject(comment));
        _announceRootStateHasChanged?.Invoke();
        await Task.CompletedTask;
    }
}