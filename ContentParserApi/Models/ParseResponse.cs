namespace ContentParserApi.Models;

public class ParseResponse
{
    public bool Success { get; set; }

    public int Count { get; set; }

    public IEnumerable<object> Data { get; set; } = [];
}
