namespace Project1_Angular.Services
{
    public interface IUtilizadorService
    {
        Task<IEnumerable<Utilizador>> GetAllUsersAsync();
        Task<UtilizadorDto> GetUserByIdAsync(int id);
        Task<bool> RegisterUserAsync(RegisterDto registerDto);
        Task<TokenDto> LoginAsync(LoginDto loginDto);
    }
}
