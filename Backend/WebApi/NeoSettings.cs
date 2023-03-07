#nullable enable
using Neo4j.Driver;

namespace WebApi;

public class NeoSettings
{
    public required Uri Connection { get; set; }
    public required IAuthToken AuthToken { get; set; }
}