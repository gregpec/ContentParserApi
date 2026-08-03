using System.Text;

namespace ContentParserApi.Services;

public class Base64ContentDecoder : IContentDecoder
{
    public string Decode(string content)
    {
        return Encoding.UTF8.GetString(
            Convert.FromBase64String(content));
    }
}
