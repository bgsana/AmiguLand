using AmiguLand.API.DTOs;

namespace AmiguLand.API.Services.Interfaces;

public interface IJwtService
{
    string GenerateToken(UserDto user);
}