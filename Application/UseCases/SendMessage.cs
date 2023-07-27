using Application.Contracts.Driven.Auth0;
using Application.Contracts.Driving.SignalR.Dtos;

namespace Application.UseCases;

public interface ISendMessage
{
    Task<MessageResponse> HandleAsync(string accessToken, SendMessageRequest req);
}

public record SendMessage : ISendMessage
{
    private readonly IAuth0Driven _auth0Driven;

    public SendMessage(IAuth0Driven auth0Driven)
    {
        _auth0Driven = auth0Driven;
    }

    public async Task<MessageResponse> HandleAsync(string accessToken, SendMessageRequest req)
    {
        // authorize and read info, throw exception if unauthorized
        // var authorInfo = _auth0Driven.AuthorizeAndReadToken(accessToken);

        await Task.CompletedTask;

        return new MessageResponse
        {
            Id = Guid.Empty,
            ConversationId = Guid.NewGuid(),
            Message = req.Message,
            CreatedAt = new DateTime()
        };
    }
}