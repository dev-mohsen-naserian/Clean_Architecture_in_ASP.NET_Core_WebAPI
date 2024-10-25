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
    public Task<UserEntity> GetByEmailAsync(string Email)
    {
        throw new NotImplementedException();
    }
}
