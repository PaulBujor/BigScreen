using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BigScreen.SDK.DataAccess.Test")]
[assembly: InternalsVisibleTo("BigScreen.SDK.WebAPI.Test")]

namespace BigScreen.SDK.DataAccess;

/// <summary>
///     This class makes the 'internal' classes in this namespace visible to unit tests
/// </summary>
internal class AssemblyInfo
{
}