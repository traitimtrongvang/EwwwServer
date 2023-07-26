using Api.Constants;
using Api.Models;
using Application.Contracts.Driving.Api.Dtos;
using Application.Exceptions;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public interface IUsersController
{
    public Task<IActionResult> RegisterNewUserAsync(RegisterNewUserRequest req);
}

public class UsersController : ControllerBase, IUsersController
{
    private readonly IRegisterNewUser _registerNewUser;

    public UsersController(IRegisterNewUser registerNewUser)
    {
        _registerNewUser = registerNewUser;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterNewUserAsync(RegisterNewUserRequest req)
    {
        try
        {
            await _registerNewUser.HandleAsync(req);
            
            return Ok(new Response
            {
                Code = ResponseCode.Ok
            });
        }
        catch (UserAlreadyRegisterExc)
        {
            return BadRequest(new Response
            {
                Code = ResponseCode.BadRequest,
                Message = "user is already exits"
            });
        }
    }
}