using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TermController : ControllerBase
{
    private readonly IDriver _context;

    public TermController(IDriver context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<Results<Ok<IServerInfo>, NotFound>> Test()
    {
        var info = await _context.GetServerInfoAsync();
        return TypedResults.Ok(info);
    }
}