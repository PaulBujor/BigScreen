namespace BigScreen.SDK.DataAccess.Exceptions;

public class UpdateFailedException : Exception
{
    private readonly string _itemId;
    private readonly Exception _reason;

    public UpdateFailedException(string itemId, Exception reason)
    {
        _reason = reason;
        _itemId = itemId;
    }

    public override string Message => $"Could not update item with ID = {_itemId}";

    public override Exception GetBaseException()
    {
        return _reason;
    }
}