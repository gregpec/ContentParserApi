using ContentParserApi.Models;
using ContentParserApi.Parsers;
using Microsoft.AspNetCore.Mvc;

namespace ContentParserApi.Controllers;

[ApiController]
[Route("api/v1")]
public class ParseContentController : ControllerBase
{
    private readonly IEnumerable<IContentParser> _parsers;

    public ParseContentController(IEnumerable<IContentParser> parsers)
    {
        _parsers = parsers;
    }

    [HttpPost("parse-content")]
    public IActionResult Parse(ParseRequest request)
    {
        return Ok("Endpoint działa.");
    }
}