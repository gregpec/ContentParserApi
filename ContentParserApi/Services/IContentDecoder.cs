namespace ContentParserApi.Services;

public interface IContentDecoder
{
    string Decode(string content);
}