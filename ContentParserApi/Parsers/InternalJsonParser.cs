using ContentParserApi.Enums;
using ContentParserApi.Models;
namespace ContentParserApi.Parsers;

public class InternalJsonParser : IContentParser
{
    public ContentType Type => ContentType.INTERNAL_JSON;

    public List<ParsedRecord> Parse(string content)
    {
        throw new NotImplementedException();
    }
}