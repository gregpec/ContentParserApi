using ContentParserApi.Enums;

namespace ContentParserApi.Parsers;

public class InternalJsonParser : IContentParser
{
    public ContentType Type => ContentType.INTERNAL_JSON;

    public IEnumerable<object> Parse(string content)
    {
        throw new NotImplementedException();
    }
}