namespace BigScreen.Frontend.Core.Exceptions;

public class UserDoesNotExistException : Exception
{
    public override string Message => "User does not exist";
}