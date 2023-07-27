using System.Diagnostics.CodeAnalysis;

namespace Application.Contracts.Driving.SignalR.Dtos;

// TODO implement it
public record SendMessageRequest
{
    public required string ReceiverEmail { get; init; }
    
    public required string Message { get; init; }

    [SetsRequiredMembers]
    public SendMessageRequest(string receiverEmail, string message)
    {
        ReceiverEmail = receiverEmail;
        Message = message;
    }
}