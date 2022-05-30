using System.Runtime.Serialization;

namespace BigScreen.SDK.WebAPI.Core;

[DataContract]
public abstract class BaseObject
{
    [DataMember] public string? Id { get; set; }

    protected bool Equals(BaseObject other)
    {
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((BaseObject) obj);
    }

    public override int GetHashCode()
    {
        return Id != null ? Id.GetHashCode() : 0;
    }
}