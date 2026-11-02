namespace SharedKernel;

public sealed class Result
{
    private Result(bool success, string? error)
    {
        Success = success;
        Error = error;
    }

    public bool Success { get; }
    public string? Error { get; }

    public static Result Ok() => new(true, null);
    public static Result Fail(string error) => new(false, error);
}
