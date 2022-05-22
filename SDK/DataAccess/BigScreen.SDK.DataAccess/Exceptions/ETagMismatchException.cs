namespace BigScreen.SDK.DataAccess.Exceptions;

public class ETagMismatchException : Exception
{
    private readonly string _etag;
    private readonly string _itemId;

    public ETagMismatchException(string itemId, string etag)
    {
        _itemId = itemId;
        _etag = etag;
    }

    public override string Message => $"The ETag for item with ID = {_itemId} is different than {_etag}";
}