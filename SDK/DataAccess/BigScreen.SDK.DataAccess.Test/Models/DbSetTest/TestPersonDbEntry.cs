using System;
using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Core.Attributes;
using Newtonsoft.Json;

namespace BigScreen.SDK.DataAccess.Test.Models.DbSetTest;

[DbContainer(PartitionKey = "LastName")]
public class TestPersonDbEntry : BaseDbEntry
{
    [JsonProperty("FirstName")] public string? FirstName { get; set; }

    [JsonProperty("LastName")] public string? LastName { get; set; }

    private bool Equals(TestPersonDbEntry other)
    {
        return FirstName == other.FirstName && LastName == other.LastName;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((TestPersonDbEntry) obj);
    }

    public override int GetHashCode()
    {
        // ReSharper disable twice NonReadonlyMemberInGetHashCode
        return HashCode.Combine(FirstName, LastName);
    }
}