using Project1_Angular.Data;
using Project1_Angular.DTOs;
using Project1_Angular.Models;
using Project1_Angular.Services;
using Microsoft.EntityFrameworkCore;

namespace Project1_Angular.Services
{
    public class UtilizadorService : IUtilizadorService
    {
        private readonly ApplicationDbContext _context;

        public UtilizadorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RegisterResultDto> RegisterUserAsync(RegisterDto dto)
        {
            var exists = await _context.Utilizadores.AnyAsync(u => u.Email == dto.Email);
            if (exists)
            {
                return new RegisterResultDto
                {
                    Sucess = false,
                    Message = "Email já existe."
                };
            }

            var utilizador = new Utilizador
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = dto.Password 
            };

            _context.Utilizadores.Add(utilizador);
            await _context.SaveChangesAsync();

            return new RegisterResultDto { Sucess = true };
        }

        // The rest can throw NotImplementedException() if unused
        public Task<IEnumerable<Utilizador>> GetAllUsersAsync() => throw new NotImplementedException();
        public Task<UtilizadorDto> GetUserByIdAsync(int id) => throw new NotImplementedException();
        public Task<TokenDto?> LoginAsync(LoginDto loginDto) => throw new NotImplementedException();
    }

}
