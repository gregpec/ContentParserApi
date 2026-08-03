using ContentParserApi.Models;
namespace ContentParserApi.Models;

public class ParseResponse
{
    public bool Success { get; set; }

    public int Count { get; set; }

    public List<ParsedRecord> Data { get; set; } = [];
}
