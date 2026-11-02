using SharedKernel;
using Xunit;

namespace OrderService.Tests;

public sealed class ResultTests
{
    [Fact]
    public void Ok_IsSuccessWithoutError()
    {
        var result = Result.Ok();

        Assert.True(result.Success);
        Assert.Null(result.Error);
    }

    [Fact]
    public void Fail_IsFailureWithError()
    {
        var result = Result.Fail("boom");

        Assert.False(result.Success);
        Assert.Equal("boom", result.Error);
    }
}
