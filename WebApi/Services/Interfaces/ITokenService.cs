using Domain.Entities.User;

namespace WebApi.Services.Interfaces;
    public interface ITokenService
    {
    string CreateToken(UserEntity user);
    }

