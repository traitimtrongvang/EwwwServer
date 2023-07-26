using EwwwApi.Constants;

namespace EwwwApi.Models;

public record Response
{
    public required ResponseCode Code { get; init; }
    public string? Message { get; init; }
}

public record Response<T> : Response
{
    public required T Payload { get; init; }
}