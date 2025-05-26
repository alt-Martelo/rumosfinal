using Project1_Angular.DTOs;    

namespace Project1_Angular.Services

{
    public interface IComentarioService
    {
        Task<IEnumerable<ComentarioDto>> GetComentariosByReceitaIdAsync(int receitaId);
        Task<bool> CreateComentarioAsync(ComentarioCreateDto comentarioDto);
        Task<bool> DeleteComentarioAsync(int id);
    
    }
}
