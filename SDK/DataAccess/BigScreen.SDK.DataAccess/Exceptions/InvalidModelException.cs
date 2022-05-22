namespace BigScreen.SDK.DataAccess.Exceptions;

public class InvalidModelException : Exception
{
    private readonly string _missingField;

    public InvalidModelException(string missingField)
    {
        _missingField = missingField;
    }

    public override string Message => $"Item does not have field {_missingField}";
}