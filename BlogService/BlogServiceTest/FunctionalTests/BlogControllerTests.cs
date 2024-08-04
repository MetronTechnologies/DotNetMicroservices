using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;
using System.Net.Http.Json;
using Blog.Domain.Entities;
using Xunit.Abstractions;

namespace BlogServiceTest.FunctionalTests; 

[ExcludeFromCodeCoverage]
public class BlogControllerTests : BaseTest, IClassFixture<CustomWebApiFactory> {

    private readonly CustomWebApiFactory _factory;
    private readonly ITestOutputHelper _outputHelper;
    public BlogControllerTests(CustomWebApiFactory factory, ITestOutputHelper outputHelper) : base(factory) {
        _factory = factory;
        _outputHelper = outputHelper;
    }

    [Fact]
    public async Task ReturnExpectedResponse() {
        IEnumerable<BlogModel>? result = await Client
            .GetFromJsonAsync<IEnumerable<BlogModel>>("api/Blog");
        result.Count().Should().BeGreaterThan(0);
    }
    
}