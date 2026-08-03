using ContentParserApi.Models;
using ContentParserApi.Parsers;
using ContentParserApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContentParserApi.Controllers;

[ApiController]
[Route("api/v1")]
public class ParseContentController : ControllerBase
{
    private readonly IEnumerable<IContentParser> _parsers;

    private readonly IContentDecoder _decoder;

    public ParseContentController(
        IEnumerable<IContentParser> parsers,
        IContentDecoder decoder)
    {
        _parsers = parsers;
        _decoder = decoder;
    }

    [HttpPost("parse-content")]
    public IActionResult Parse(ParseRequest request)
    {

        Console.WriteLine("Parse endpoint called");
        var parser = _parsers.FirstOrDefault(p => p.Type == request.Type);
        if (parser == null)
        {
            return BadRequest("Brak parsera dla podanego typu.");
        }
        //return Ok("Endpoint działa.");
        var decodedContent = _decoder.Decode(request.Content);
        var records = parser.Parse(decodedContent);
        return Ok(records);
    }
}