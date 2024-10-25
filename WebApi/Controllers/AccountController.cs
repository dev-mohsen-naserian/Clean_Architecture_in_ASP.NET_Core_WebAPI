using Application.Services.Interfaces;
using Domain.DTOs.User;
using Domain.Entities.User;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers;

public class AccountController(IUserService userService,ITokenService tokenService) : BaseApiController
{
    #region Actions
    [HttpPost]
    public async Task<IActionResult> Login(LoginDto model)
    {
        var Result = await userService.LoginAsync(model);
        switch (Result)
        {
            case LoginResult.Success:
                var user = await userService.GetByEmailAsync(model.Email);
                return new JsonResult( new UserDto() {Avatar = null, DisplayName = user.DisplayName,Token = tokenService.CreateToken(user),UserName=user.UserName });
            case LoginResult.Error:
                return Unauthorized();
            case LoginResult.UserNotFound:
                return Unauthorized();
        }
        return Ok();
    }
    #endregion

}
