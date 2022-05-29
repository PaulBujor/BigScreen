using BigScreen.Core.Models.BigScreen;
using BigScreen.Frontend.Client.Handlers.Interfaces;

namespace BigScreen.Frontend.Client.Handlers;

public class DiscussionHandler : IDiscussionHandler
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

    public async Task<IEnumerable<CommentDto>> GetComments(string mediaId)
    {
        return await Task.FromResult(_dummyComments.Where(c => c.ForMovie == mediaId).ToList());
    }

    public async Task<CommentDto> PostCommentAsync(CommentDto comment)
    {
        comment.Id = Guid.NewGuid().ToString();
        _dummyComments.Add(comment);
        return await Task.FromResult(comment);
    }
}