using OnionPronia.Application.DTOs;
using OnionPronia.Application.DTOs.AppUsers;
using OnionPronia.Application.DTOS;

namespace OnionPronia.Application.Interface.Services
{
    public interface IAuthenticationService
    {
        Task RegisterAsync(RegisterDto userDto);
        Task<string> LogInAsync(LoginDto userDto);
    }
}
