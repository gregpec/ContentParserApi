using ContentParserApi.Enums;
using ContentParserApi.Models;

namespace ContentParserApi.Parsers;

public class CsvParser : IContentParser
{
    public ContentType Type => ContentType.CSV;

    public List<ParsedRecord> Parse(string content)
    {
        throw new NotImplementedException();
    }
}