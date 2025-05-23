namespace Project1_Angular.Services
{
    public interface IReceitaService
    {
        Task<IEnumerable<ReceitaDto>> GetAllReceitasAsync();
        Task<ReceitaDto> GetReceitaByIdAsync(int id);
        Task<bool> CreateReceitaAsync(CreateReceitaDto receitaDto);
        Task<bool> UpdateReceitaAsync(int id, UpdateReceitaDto receitaDto);
        Task<bool> DeleteReceitaAsync(int id);
    }
}
