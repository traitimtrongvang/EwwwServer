using System.Diagnostics.CodeAnalysis;

namespace Application.ValueObjects;

public record AuthId
{
    public required string Value { get; init; }

    [SetsRequiredMembers]
    public AuthId(string value)
    {
        Value = value;
    }

    public static explicit operator AuthId(string authIdStr)
        => new AuthId(authIdStr);
};