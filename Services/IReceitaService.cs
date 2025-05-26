using Project1_Angular.DTOs;

namespace Project1_Angular.Services
{
    public interface IReceitaService
    {
        Task<IEnumerable<ReceitaDto>> GetAllReceitasAsync();
        Task<ReceitaDto> GetReceitaByIdAsync(int id);
        Task<ReceitaDto> CreateReceitaAsync(ReceitaCreateDto receitaDto);
        Task<bool> UpdateReceitaAsync(int id, ReceitaUpdateDto receitaDto);
        Task<bool> DeleteReceitaAsync(int id);
    }
}
