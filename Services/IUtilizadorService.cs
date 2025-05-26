using Project1_Angular.Models;
using Project1_Angular.DTOs;

namespace Project1_Angular.Services
{
    public interface IUtilizadorService
    {
        Task<IEnumerable<Utilizador>> GetAllUsersAsync();
        Task<UtilizadorDto> GetUserByIdAsync(int id);
        Task<RegisterResultDto> RegisterUserAsync(RegisterDto registerDto);
        Task<TokenDto> LoginAsync(LoginDto loginDto);

    }
}
