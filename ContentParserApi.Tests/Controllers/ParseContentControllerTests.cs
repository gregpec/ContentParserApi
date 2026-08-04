using System.Net;
using System.Text;
using System.Text.Json;
using ContentParserApi.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace ContentParserApi.Tests.Controllers;

public class ParseContentControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ParseContentControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Parse_ValidCsv_ReturnsSuccessResponse()
    {
        // Arrange
        var csv =
            "Id,Brand,Processor,Ram,Ssd\n" +
            "1,Dell,i5,16,512";

        var base64 = Convert.ToBase64String(
            Encoding.UTF8.GetBytes(csv));

        var request =
            $"{{\"type\":\"CSV\",\"content\":\"{base64}\"}}";

        var httpContent = new StringContent(
            request,
            Encoding.UTF8,
            "application/json");

        // Act
        var response = await _client.PostAsync(
            "/api/v1/parse-content",
            httpContent);

        // Assert - HTTP
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        // Assert - Response body
        var responseBody = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<ParseResponse>(
            responseBody,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        Assert.NotNull(result);
        Assert.Equal("success", result.Status);
        Assert.Equal(1, result.Count);
        Assert.NotNull(result.Data);
        Assert.Single(result.Data);

        var record = result.Data.First();

        Assert.Equal("1", ((JsonElement)record.Fields["Id"]!).GetString());
        Assert.Equal("Dell", ((JsonElement)record.Fields["Brand"]!).GetString());
        Assert.Equal("i5", ((JsonElement)record.Fields["Processor"]!).GetString());
        Assert.Equal("16", ((JsonElement)record.Fields["Ram"]!).GetString());
        Assert.Equal("512", ((JsonElement)record.Fields["Ssd"]!).GetString());
    }
}