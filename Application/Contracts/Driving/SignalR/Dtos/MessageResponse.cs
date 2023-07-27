namespace Application.Contracts.Driving.SignalR.Dtos;

public record MessageResponse
{
    public required Guid Id { get; init; }
    
    public required Guid ConversationId { get; init; }
    
    public required string Message { get; init; }

    public required DateTime CreatedAt { get; init; }
}