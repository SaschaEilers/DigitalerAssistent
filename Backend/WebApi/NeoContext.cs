#nullable enable
using Neo4j.Driver;

namespace WebApi;

public sealed class NeoContext : INeoContext,IAsyncDisposable
{
    private IDriver _driver;

    public NeoContext(ILogger<NeoContext> logger, NeoSettings settings)
    {
    }

    public ValueTask DisposeAsync()
    {
        return _driver.DisposeAsync();
    }
}

public interface INeoContext
{
}