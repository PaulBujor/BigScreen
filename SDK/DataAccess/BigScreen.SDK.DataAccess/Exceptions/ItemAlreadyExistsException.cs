namespace BigScreen.SDK.DataAccess.Exceptions;

public class ItemAlreadyExistsException : Exception
{
    public ItemAlreadyExistsException(string guid)
    {
        Guid = guid;
    }

    private string Guid { get; }
    public override string Message => $"An item with {Guid} already exists, and you cannot overwrite it";
}