using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver;
using WebApi.DB.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class TermController : ControllerBase
{
    private readonly IDatabaseService<Term> _context;

    public TermController(IDatabaseService<Term> context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<Results<Ok<IAsyncEnumerable<Term>>, EmptyHttpResult>> GetTerms()
    {
        return TypedResults.Ok(await _context.);
    }
    
    [HttpPost]
    public async Task<Results<Created<Term>, BadRequest>> CreateTerm()
    {
        
    }
}