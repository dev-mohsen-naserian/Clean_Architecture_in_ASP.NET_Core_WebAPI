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
}
