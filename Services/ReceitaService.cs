using Project1_Angular.DTOs;
using Project1_Angular.Models;
using Microsoft.EntityFrameworkCore;
using Project1_Angular.Data;
using System.Security.Claims;

namespace Project1_Angular.Services
{
    public class ReceitaService : IReceitaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReceitaService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ReceitaDto> CreateReceitaAsync(ReceitaCreateDto dto)
        {
            // Get the logged-in username from the JWT claims
            var username = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
            if (string.IsNullOrEmpty(username))
                throw new UnauthorizedAccessException("User is not logged in.");

            // Find the corresponding user in the database
            var utilizador = await _context.Utilizadores
                .FirstOrDefaultAsync(u => u.Username == username);

            if (utilizador == null)
                throw new Exception("Utilizador not found.");

            // Create new Receita
            var receita = new Receita
            {
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                Categoria = dto.Categoria, 
                Ingredientes = dto.Ingredientes.Select(i => new IngredienteReceita { Nome = i }).ToList(),
                Utilizador = utilizador,
                DataCriacao = DateTime.UtcNow,
                Comentarios = new List<Comentario>() /
            };

            _context.Receitas.Add(receita);
            await _context.SaveChangesAsync();

            return new ReceitaDto
            {
                Id = receita.Id,
                Titulo = receita.Titulo,
                Descricao = receita.Descricao,
                Categoria = receita.Categoria,
                Ingredientes = receita.Ingredientes.Select(i => i.Nome).ToList(),
                CriadoPorUsername = receita.Utilizador.Username,
                DataCriacao = receita.DataCriacao
            };
        }
        public Task<IEnumerable<ReceitaDto>> GetAllReceitasAsync() => throw new NotImplementedException();
        public Task<bool> UpdateReceitaAsync(int id, ReceitaUpdateDto receitaDto) => throw new NotImplementedException();
        public Task<bool> DeleteReceitaAsync(int id) => throw new NotImplementedException();

        public Task<ReceitaDto> GetReceitaByIdAsync(int id) => throw new NotImplementedException();


    }


}
