using Application.Extensions;
using Application.Services.Interfaces;
using Domain.DTOs.User;
using Domain.Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers;

public class AccountController(IUserService userService, ITokenService tokenService) : BaseApiController
{
    #region Actions
    #region Login
    [HttpPost]
    public async Task<IActionResult> Login(LoginDto model)
    {
        var Result = await userService.LoginAsync(model);
        switch (Result)
        {
            case LoginResult.Success:
                var user = await userService.GetByEmailAsync(model.Email);
                return new JsonResult(new UserDto() { Avatar = user.Avatar, DisplayName = user.DisplayName, Token = tokenService.CreateToken(user), UserName = user.UserName });
            case LoginResult.Error:
                return Unauthorized();
            case LoginResult.UserNotFound:
                return Unauthorized();
        }
        return Ok();
    }
    #endregion
    #region Register
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterDto model)
    {
        #region Validation
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        #endregion
        var Result = await userService.RegisterAsync(model);
        switch (Result)
        {
            case RegisterResult.Success:
                var user = await userService.GetByEmailAsync(model.Email);
                return new JsonResult(new UserDto() { Avatar = user.Avatar, DisplayName = user.DisplayName, Token = tokenService.CreateToken(user), UserName = user.UserName });
            case RegisterResult.Error:
                return BadRequest("Operation Fail");
            case RegisterResult.DublicatedEmail:
                return BadRequest("Email is exists please enter your account"); ;
        }
        return BadRequest();
    }

    #endregion
    #region Get Current User
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetCurrentUser() 
    {
        var user = await userService.GetByIdAsync(User.GetUserId());
        return new JsonResult(new UserDto() { Avatar = user.Avatar, DisplayName = user.DisplayName, UserName = user.UserName });
    }
    #endregion
    #endregion

}
