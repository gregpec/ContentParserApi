using ContentParserApi.Enums;
using ContentParserApi.Models;

namespace ContentParserApi.Parsers;

public class CsvParser : IContentParser
{
    public ContentType Type => ContentType.CSV;

    public List<ParsedRecord> Parse(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            return new List<ParsedRecord>();
        }
        var lines = content.Split(['\r', '\n'],StringSplitOptions.RemoveEmptyEntries);
        var records = new List<ParsedRecord>();
        var headers = lines[0].Split(',');
       
        for (int i = 1; i < lines.Length; i++)
        {
            var record = new ParsedRecord();
            var values = lines[i].Split(',');
            if (values.Length != headers.Length)
            {
                throw new FormatException("The number of values ​​does not match the number of headers.");
            }
            for (int j = 0; j < headers.Length; j++)
            {
                record.Fields[headers[j].Trim()] = values[j].Trim();
            }
            records.Add(record);
        }
        return records;
    }
}