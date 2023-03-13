#nullable enable
using Microsoft.Extensions.Logging;
using Neo4j.Driver;

namespace WebApi.DB.Configuration;

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