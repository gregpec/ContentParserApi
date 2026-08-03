using ContentParserApi.Models;
namespace ContentParserApi.Models;

public class ParseResponse
{
    public string Status { get; set; } = string.Empty;

    public int Count { get; set; }

    public List<ParsedRecord> Data { get; set; } = [];
}
