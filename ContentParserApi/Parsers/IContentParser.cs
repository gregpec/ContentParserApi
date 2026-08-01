using ContentParserApi.Enums;

namespace ContentParserApi.Parsers;

public interface IContentParser
{
    ContentType Type { get; }

    IEnumerable<object> Parse(string content);
}