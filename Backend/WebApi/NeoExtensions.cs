#nullable enable
using Neo4j.Driver;
using ILogger = Neo4j.Driver.ILogger;

namespace WebApi;

public static class NeoExtensions
{
    public static IServiceCollection AddNeo4j(this IServiceCollection collection, NeoSettings settings)
    {
        return collection.AddScoped<IDriver>(provider => GraphDatabase.Driver(settings.Connection, settings.AuthToken));
    }
}