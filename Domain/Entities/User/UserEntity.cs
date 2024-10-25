using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User;

public class UserEntity
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public bool IsEmailActive { get; set; }
    public string Mobile { get; set; }
    public string Avatar { get; set; }
    public string DisplayName { get; set; }
    public DateTime RegisterDate { get; set; }
}
