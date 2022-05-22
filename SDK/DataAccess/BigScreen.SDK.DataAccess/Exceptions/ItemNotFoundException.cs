namespace BigScreen.SDK.DataAccess.Exceptions;

public class ItemNotFoundException : Exception
{
    private readonly string _itemId;

    public ItemNotFoundException(string itemId)
    {
        _itemId = itemId;
    }

    public override string Message => $"Could not find item with ID = {_itemId}";
}