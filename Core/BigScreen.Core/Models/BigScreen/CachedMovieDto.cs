using System.Runtime.Serialization;
using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.Core.Models.BigScreen;

[DataContract]
public class CachedMovieDto : BaseObject
{
    [DataMember(Name = "title")] public string? Title { get; set; }

    [DataMember(Name = "posterImageUrl")] public string? PosterImageUrl { get; set; }
}