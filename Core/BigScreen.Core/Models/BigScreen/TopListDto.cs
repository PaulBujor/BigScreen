using System.Runtime.Serialization;
using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.Core.Models.BigScreen;

[DataContract]
public class TopListDto : BaseDto
{
    [DataMember(Name = "title")] public string? Title { get; set; }
    [DataMember(Name = "owner")] public CachedUserDto? Owner { get; set; }

    [DataMember(Name = "isPrivate")] public bool? IsPrivate { get; set; }

    [DataMember(Name = "movies")] public ICollection<CachedMovieDto>? Movies { get; set; }

    public CachedTopListDto GetCachedVersion()
    {
        return new CachedTopListDto
        {
            Id = Id,
            Title = Title
        };
    }
}