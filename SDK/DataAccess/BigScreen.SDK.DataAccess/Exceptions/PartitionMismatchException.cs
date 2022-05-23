namespace BigScreen.SDK.DataAccess.Exceptions;

public class PartitionMismatchException : Exception
{
    private readonly string _itemId;
    private readonly string _partition;

    public PartitionMismatchException(string itemId, string partition)
    {
        _itemId = itemId;
        _partition = partition;
    }

    public override string Message => $"The partition for item with ID = {_itemId} is different than {_partition}";
}