using ContentParserApi.Enums;

namespace ContentParserApi.Parsers;

public class CsvParser : IContentParser
{
    public ContentType Type => ContentType.CSV;

    public IEnumerable<object> Parse(string content)
    {
        throw new NotImplementedException();
    }
}