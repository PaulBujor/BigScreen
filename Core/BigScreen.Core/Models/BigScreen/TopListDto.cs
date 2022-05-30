using System.Runtime.Serialization;
using BigScreen.SDK.WebAPI.Core;
using BigScreen.SDK.WebAPI.Core.Attributes;
using Microsoft.OData.ModelBuilder;

namespace BigScreen.Core.Models.BigScreen;

[DataContract]
[EdmCollection("TopLists")]
public class TopListDto : BaseDto
{
    [DataMember] public string? Title { get; set; }

    [AutoExpand] [DataMember] public CachedUserDto? Owner { get; set; }

    [DataMember] public bool? IsPrivate { get; set; }

    [AutoExpand] [DataMember] public ICollection<CachedMovieDto>? Movies { get; set; }

    public CachedTopListDto GetCachedVersion()
    {
        return new CachedTopListDto
        {
            Id = Id,
            Title = Title
        };
    }
}