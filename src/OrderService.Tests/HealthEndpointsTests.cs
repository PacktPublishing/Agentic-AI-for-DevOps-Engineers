using Xunit;

namespace OrderService.Tests;

public sealed class HealthEndpointsTests
{
    [Fact]
    public void GetHealthResponse_ReturnsOkStatus()
    {
        var response = HealthEndpoints.GetHealthResponse();

        Assert.Equal("ok", response.Status);
    }
}
