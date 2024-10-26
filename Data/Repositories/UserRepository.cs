using Domain.Contrators;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories;

public class UserRepository : IUserRepository
{
    public Task<bool> DublicatedEamilAsync(string Email)
    {
        throw new NotImplementedException();
    }

    public Task<UserEntity> GetByEmailAsync(string Email)
    {
        throw new NotImplementedException();
    }

    public Task<UserEntity> GetByIdAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public Task InsertAsync()
    {
        throw new NotImplementedException();
    }
}
