using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contrators;

public interface IUserRepository
{
    Task<UserEntity> GetByEmailAsync(string Email);
    Task<UserEntity> GetByIdAsync(int Id);
    Task<bool> DublicatedEamilAsync(string Email);

    Task InsertAsync();
}
