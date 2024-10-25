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
    #endregion

}
