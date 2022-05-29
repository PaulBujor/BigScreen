namespace BigScreen.SDK.WebAPI.Core.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
public class EdmCollectionAttribute : Attribute
{
    public EdmCollectionAttribute(string collectionName)
    {
        CollectionName = collectionName;
    }

    public string CollectionName { get; }
}