using ContentParserApi.Enums;
using ContentParserApi.Models;

namespace ContentParserApi.Parsers;

public interface IContentParser
{
    ContentType Type { get; }

    List<ParsedRecord> Parse(string content);
}