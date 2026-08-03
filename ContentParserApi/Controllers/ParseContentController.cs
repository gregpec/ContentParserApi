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
        if (request == null)
        {
            return BadRequest(new
            {
                status = "error",
                message = "Request body is required."
            });
        }
        //Console.WriteLine("Parse endpoint called");
        var parser = _parsers.FirstOrDefault(p => p.Type == request.Type);
        if (parser == null)
        {
            return BadRequest(new
            {
                status = "error",
                message = $"Unsupported parser type '{request.Type}'."
            });

        }
        try
        {
            var decodedContent = _decoder.Decode(request.Content);
            var records = parser.Parse(decodedContent);

            var response = new ParseResponse
            {
                Status = "success",
                Count = records.Count,
                Data = records
            };

            return Ok(response);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                status = "error",
                message = "Internal server error."
            });
        }
    }

    //    return Ok("Endpoint działa.");
    //    var decodedContent = _decoder.Decode(request.Content);
    //    var records = parser.Parse(decodedContent);
    //    var response = new ParseResponse
    //    {
    //        Status = "success",
    //        Count = records.Count,
    //        Data = records
    //    };
    //    return Ok(response);
    //}
}