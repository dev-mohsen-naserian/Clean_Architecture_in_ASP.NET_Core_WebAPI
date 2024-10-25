using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.User;

public class UserDto
{
    public string UserName { get; set; }
    public string DisplayName { get; set; }
    public string Avatar { get; set; }
    public string Token { get; set; }
}
