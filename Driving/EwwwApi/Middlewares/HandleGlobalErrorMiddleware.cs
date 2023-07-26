using System.Net;
using System.Text.Json;
using Application.Contracts.Driven.Auth0.Exceptions;
using EwwwApi.Constants;
using EwwwApi.Models;
using Microsoft.AspNetCore.Http;

namespace EwwwApi.Middlewares;

public class HandleGlobalErrorMiddleware
{
    private readonly RequestDelegate _next;

    public HandleGlobalErrorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (UnauthorizedExc)
        {
            await HandleResponse(
                context,
                new Response { Code = ResponseCode.Unauthorized },
                HttpStatusCode.Unauthorized);
        }
        catch (Exception)
        {
            await HandleResponse(
                context,
                new Response { Code = ResponseCode.InternalServerError },
                HttpStatusCode.InternalServerError);
        }
    }

    private static Task HandleResponse(HttpContext context, Response response, HttpStatusCode statusCode)
    {
        var responseStr = JsonSerializer.Serialize(response, new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(responseStr);
    }
}