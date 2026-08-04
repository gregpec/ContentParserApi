using ContentParserApi.Parsers;
using Xunit;

namespace ContentParserApi.Tests.Parsers;

public class InternalJsonParserTests
{
    [Fact]
    public void Parse_ValidJson_ReturnsOneRecord()
    {
        // Arrange
        var parser = new InternalJsonParser();

        var json = """
        [
            {
                "Id": "1",
                "Brand": "Dell",
                "Processor": "i5",
                "Ram": "16",
                "Ssd": "512"
            }
        ]
        """;

        // Act
        var result = parser.Parse(json);

        // Assert
        Assert.Single(result);

        var record = result.First();

        Assert.Equal("1", record.Fields["Id"]);
        Assert.Equal("Dell", record.Fields["Brand"]);
        Assert.Equal("i5", record.Fields["Processor"]);
        Assert.Equal("16", record.Fields["Ram"]);
        Assert.Equal("512", record.Fields["Ssd"]);
    }

    [Fact]
    public void Parse_EmptyContent_ReturnsEmptyList()
    {
        // Arrange
        var parser = new InternalJsonParser();

        // Act
        var result = parser.Parse(string.Empty);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void Parse_InvalidJson_ThrowsFormatException()
    {
        // Arrange
        var parser = new InternalJsonParser();

        var json = "{ invalid json }";

        // Act & Assert
        Assert.Throws<FormatException>(() => parser.Parse(json));
    }

    [Fact]
    public void Parse_EmptyJsonArray_ReturnsEmptyList()
    {
        // Arrange
        var parser = new InternalJsonParser();

        var json = "[]";

        // Act
        var result = parser.Parse(json);

        // Assert
        Assert.Empty(result);
    }
}