namespace BigScreen.SDK.DataAccess.Exceptions;

public class InvalidGuidException : Exception
{
    public InvalidGuidException(string guid)
    {
        Guid = guid;
    }

    private string Guid { get; }
    public override string Message => $"{Guid} is not a valid GUID";
}