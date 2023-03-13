using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;
using Neo4j.Driver;
using Neo4j.Driver.Experimental;

namespace WebApi.DB.Services;

public sealed class TermService : IDatabaseService<Term>
{
    private readonly ILogger<TermService> _service;
    private readonly IDriver _driver;

    public TermService(ILogger<TermService> service, IDriver driver)
    {
        _service = service;
        _driver = driver;
    }
    
    public async IAsyncEnumerable<Term> GetTermsAsync(CancellationToken cancellationToken)
    {
        try
        {
            await _driver.VerifyConnectivityAsync();
        }
        catch (Exception e)
        {
            _service.LogError(e, "could not connect to the server");
            yield break;
        }

        await using var a = _driver.AsyncSession();
        var resultCursor = await a.RunAsync("MATCH (term:Term) RETURN term");
        await foreach (var record in resultCursor)
        {
            Console.WriteLine("Hello");
        }
    }

    public Task<Term> CreateTermAsync(string bla)
    {
        return Task.FromResult(new Term
        {
            Value = "ball",
            Weight = 0.123456789m,
            CreationTimeStamp = DateTimeOffset.UtcNow,
            ModifiedTimeStamp = DateTimeOffset.UtcNow
        });
    }

    public IAsyncEnumerable<Term> GetTermsAsync(ulong? uid)
    {
        throw new NotImplementedException();
    }

    public Task<Term> CreateTermAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Term> UpdateTermAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Term> DeleteTermAsync(long uid)
    {
        throw new NotImplementedException();
    }
}

public interface IDatabaseService<T>
{
    IAsyncEnumerable<Term> GetTermsAsync(ulong? uid);
    Task<Term> CreateTermAsync();

    Task<Term> UpdateTermAsync();

    Task<Term> DeleteTermAsync(long uid);
}