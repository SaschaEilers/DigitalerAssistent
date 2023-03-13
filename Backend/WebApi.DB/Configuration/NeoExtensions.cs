#nullable enable
using Microsoft.Extensions.DependencyInjection;
using Neo4j.Driver;
using WebApi.DB.Services;

namespace WebApi;

public static class NeoExtensions
{
    public static IServiceCollection AddNeo4j(this IServiceCollection collection, NeoSettings settings)
    {
        collection.AddScoped<IDatabaseService<Term>, TermService>();
        return collection.AddScoped<IDriver>(provider => GraphDatabase.Driver(settings.Connection, settings.AuthToken));
    }
}