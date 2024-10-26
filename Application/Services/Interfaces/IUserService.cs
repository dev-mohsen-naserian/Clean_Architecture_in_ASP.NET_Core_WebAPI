using Domain.DTOs.User;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces;

public interface IUserService
{
    Task<LoginResult> LoginAsync(LoginDto model);
    Task<UserEntity> GetByEmailAsync(string Email);
    Task<UserEntity> GetByIdAsync(int Id);
    Task<RegisterResult> RegisterAsync(RegisterDto model);

}
