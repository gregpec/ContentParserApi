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
        var parser = _parsers.FirstOrDefault(p => p.Type == request.Type);
        if (parser == null)
        {
            return BadRequest(new
            {
                status = "error",
                message = $"Unsupported parser type '{request.Type}'."
            });

        }
            string decodedContent;
            try
            {
                decodedContent = _decoder.Decode(request.Content);
            }
            catch (FormatException)
            {
                return BadRequest(new
                {
                    status = "error",
                    message = "Invalid Base64 content."
                });
            }
            try
            {
                var records = parser.Parse(decodedContent);

                var response = new ParseResponse
                {
                    Status = "success",
                    Count = records.Count,
                    Data = records
                };

                return Ok(response);
            }
            catch (FormatException ex)
            {
                return BadRequest(new
                {
                    status = "error",
                    message = ex.Message
                });
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
      }



    
