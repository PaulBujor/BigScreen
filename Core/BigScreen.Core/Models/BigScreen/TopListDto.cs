using System.Runtime.Serialization;
using BigScreen.SDK.WebAPI.Core;
using BigScreen.SDK.WebAPI.Core.Attributes;

namespace BigScreen.Core.Models.BigScreen;

[DataContract]
[EdmCollection("TopLists")]
public class TopListDto : BaseDto
{
    [DataMember(Name = "title")]
    public string? Title { get; set; }

    [DataMember(Name = "owner")]
    public CachedUserDto? Owner { get; set; }

    [DataMember(Name = "isPrivate")]
    public bool? IsPrivate { get; set; }

    [DataMember(Name = "movies")]
    public ICollection<CachedMovieDto>? Movies { get; set; }

    public CachedTopListDto GetCachedVersion() => new CachedTopListDto
    {
        Id = Id,
        Title = Title
    };
}