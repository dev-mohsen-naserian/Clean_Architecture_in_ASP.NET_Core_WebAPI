using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.User;

public class RegisterDto
{
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string DisplayName { get; set; }
}
public enum RegisterResult
{
    Success,
    Error,
    DublicatedEmail
}
