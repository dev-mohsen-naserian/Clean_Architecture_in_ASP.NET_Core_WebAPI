using Application.Services.Interfaces;
using Domain.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class AccountController(IUserService userService) : BaseApiController
{
    #region Actions
    [HttpPost]
    public async Task<IActionResult> Login(LoginDto model)
    {
        var Result = await userService.LoginAsync(model);
        switch (Result)
        {
            case LoginResult.Success:
                break;
            case LoginResult.Error:
                break;
            case LoginResult.UserNotFound:
                break;
        }
        return Ok();
    }
    #endregion

}
