using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using SharedKernel;
using Xunit;

namespace OrderService.Tests;

// Runs the real app in memory, so routing and the endpoint handlers are tested.
public sealed class ApiEndpointsTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task GetHealth_ReturnsOk()
    {
        var response = await _client.GetFromJsonAsync<HealthResponse>("/health");

        Assert.Equal("ok", response?.Status);
    }

    [Fact]
    public async Task GetVersion_ReturnsProjectVersion()
    {
        var response = await _client.GetFromJsonAsync<VersionResponse>("/version");

        Assert.Equal("1.0.0", response?.Version);
    }

    [Fact]
    public async Task GetOrders_ReturnsThreeOrders()
    {
        var response = await _client.GetAsync("/api/orders");
        var orders = await response.Content.ReadFromJsonAsync<List<OrderDto>>();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(orders);
        Assert.Equal(["ORD-1001", "ORD-1002", "ORD-1003"], orders.Select(o => o.Id));
    }

    [Fact]
    public async Task UnknownRoute_ReturnsNotFound()
    {
        var response = await _client.GetAsync("/does-not-exist");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
