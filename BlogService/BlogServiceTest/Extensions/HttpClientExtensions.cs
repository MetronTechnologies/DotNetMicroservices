using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using Xunit.Abstractions;

namespace BlogServiceTest.Extensions; 

[ExcludeFromCodeCoverage]
public static class HttpClientExtensions {
    private static readonly JsonSerializerOptions _jsonPrintOptions = new() {
        WriteIndented = true
    };

    private static readonly JsonSerializerOptions _jsonSerializerOptions = new(JsonSerializerDefaults.Web) {
        Converters = {
            new JsonStringEnumConverter()
        }
    };

    public static async Task<T> GetJsonResultAsync<T>(this HttpClient client, string url, HttpStatusCode
        expectedStatus, ITestOutputHelper output) {
        HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseContentRead);
        return await DeserializeAndCheckResponse<T>(response, expectedStatus, output);
    }

    private static async Task<T> DeserializeAndCheckResponse<T>(HttpResponseMessage response, HttpStatusCode
        expectedStatus, ITestOutputHelper output) {
        Stream streamContent = await response.Content.ReadAsStreamAsync();
        try {
            T? result = await JsonSerializer.DeserializeAsync<T>(streamContent, _jsonSerializerOptions);
            response.StatusCode.Should().Be(expectedStatus);
            result.Should().NotBeNull();
            return result!;
        } catch (Exception) {
            string stringContent = await response.Content.ReadAsStringAsync();
            WriteOutput(stringContent, output);
            throw;
        }
    }

    private static void WriteOutput(string stringContent, ITestOutputHelper output) {
        string? outputText;
        try {
            JsonDocument jsonContent = JsonDocument.Parse(stringContent);
            outputText = JsonSerializer.Serialize(jsonContent, _jsonPrintOptions);
        } catch {
            outputText = stringContent;
        }
        output.WriteLine(outputText);
    }
    
    

}