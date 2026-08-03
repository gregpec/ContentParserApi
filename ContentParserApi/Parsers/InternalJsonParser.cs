using System.Text.Json;
using ContentParserApi.Enums;
using ContentParserApi.Models;

namespace ContentParserApi.Parsers;

public class InternalJsonParser : IContentParser
{
    public ContentType Type => ContentType.INTERNAL_JSON;

    public List<ParsedRecord> Parse(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            return new List<ParsedRecord>();
        }

        try
        {
            var data = JsonSerializer.Deserialize<List<Dictionary<string, object?>>>(content);

            var records = new List<ParsedRecord>();

            if (data == null)
            {
                return records;
            }

            foreach (var item in data)
            {
                var record = new ParsedRecord();

                foreach (var field in item)
                {
                    record.Fields[field.Key] = field.Value?.ToString();
                }

                records.Add(record);
            }

            return records;
        }
        catch (JsonException)
        {
            throw new FormatException("Invalid JSON format.");
        }
    }
}