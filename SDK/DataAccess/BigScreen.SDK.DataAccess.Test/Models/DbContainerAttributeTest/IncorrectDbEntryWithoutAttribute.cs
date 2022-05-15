using BigScreen.SDK.DataAccess.Core;

namespace BigScreen.SDK.DataAccess.Test.Models.DbContainerAttributeTest;

public class IncorrectDbEntryWithoutAttribute : BaseDbEntry
{
    public string? DontHaveAnAttribute { get; set; }
}