namespace Project1_Angular.Services
{
    public interface IComentarioService
    {
        Task<IEnumerable<ComentarioDto>> GetComentariosByReceitaIdAsync(int receitaId);
        Task<bool> CreateComentarioAsync(CreateComentarioDto comentarioDto);
        Task<bool> DeleteComentarioAsync(int id);
    }
}
