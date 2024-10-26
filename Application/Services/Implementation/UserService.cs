using Application.Services.Interfaces;
using Domain.Contrators;
using Domain.DTOs.User;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Application.Services.Implementation;

public class UserService(IUserRepository userRepository): IUserService
{
    #region Methods
    public async Task<LoginResult> LoginAsync(LoginDto model)
    {
        model.Email = model.Email.ToLower().Trim();
        var user = await userRepository.GetByEmailAsync(model.Email);
        if(user is null)
        {
            return LoginResult.UserNotFound;
        }
        string hashPassword = model.Password;
        if(user.Password != hashPassword)
        {
            return LoginResult.UserNotFound;
        }
        return LoginResult.Success;
    }
    public Task<UserEntity> GetByEmailAsync(string Email)
    {
        Email = Email.ToLower().Trim();
        return userRepository.GetByEmailAsync(Email);
    }
    public async Task<UserEntity> GetByIdAsync(int Id)
    {
        return await userRepository.GetByIdAsync(Id);
    }

    public async Task<RegisterResult> RegisterAsync(RegisterDto model)
    {
        model.Email=model.Email.ToLower().Trim();
        if(await userRepository.DublicatedEamilAsync(model.Email))
        {
            return RegisterResult.DublicatedEmail;
        }
        string HashPassword = model.Password;
        UserEntity user = new()
        {
            UserName = model.UserName,
            Avatar= null,
            DisplayName= model.DisplayName,
            IsEmailActive = false,
            Mobile=null,
            Email = HashPassword,
            RegisterDate= DateTime.Now,

        };
        await userRepository.InsertAsync();
        return RegisterResult.Success;
    }
    #endregion

}
