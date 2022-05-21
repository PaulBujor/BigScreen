using System.Reflection;

namespace BigScreen.SDK.Utilities;

public static class TypeExtensions
{
    public static TAttribute GetAttribute<TAttribute>(this Type type) where TAttribute : Attribute
    {
        var dbContainerAttribute = type.GetCustomAttribute<TAttribute>();
        if (dbContainerAttribute == null)
            throw new InvalidOperationException(
                $"{type.FullName} is missing the DbContainer attribute!");

        return dbContainerAttribute;
    }
    
}