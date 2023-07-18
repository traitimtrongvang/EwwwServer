using Application.ValueObjects;

namespace Application.Entities;

public class User : EntityBase
{
    public required AuthId AuthId { get; init; }
}