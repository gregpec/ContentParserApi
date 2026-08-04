using ContentParserApi.Parsers;
using Xunit;

namespace ContentParserApi.Tests.Parsers;

public class CsvParserTests
{
    [Fact]
    public void Parse_ValidCsv_ReturnsOneRecord()
    {
        // Arrange
        var parser = new CsvParser();

        var csv =
            "Id,Brand,Processor,Ram,Ssd\n" +
            "1,Dell,i5,16,512";

        // Act
        var result = parser.Parse(csv);

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
        var parser = new CsvParser();

        // Act
        var result = parser.Parse(string.Empty);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void Parse_InvalidCsv_ThrowsFormatException()
    {
        // Arrange
        var parser = new CsvParser();

        var csv =
            "Id,Brand\n" +
            "1";

        // Act & Assert
        Assert.Throws<FormatException>(() => parser.Parse(csv));
    }
}