namespace BigScreen.SDK.Client.Abstractions;
/// <summary>
/// Generic client
/// </summary>
/// <typeparam name="TDto">Dto type</typeparam>
public interface IClient<TDto> where TDto : class
{
    Task<TDto?> GetAsync(string? id, string? additionalUri, Dictionary<string, string>? query);
    
}