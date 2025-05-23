using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project1_Angular.Controllers
{
    public class ComentariosController
    {
        [ApiController]
        [Route("api/[controller]")]
        public class ComentariosController : ControllerBase
        {
            private readonly IComentarioService _comentarioService;

            public ComentariosController(IComentarioService comentarioService)
            {
                _comentarioService = comentarioService;
            }

            [HttpGet("receita/{receitaId}")]
            public async Task<IActionResult> GetByReceitaId(int receitaId)
            {
                var comentarios = await _comentarioService.ObterPorReceitaAsync(receitaId);
                return Ok(comentarios);
            }

            [Authorize]
            [HttpPost]
            public async Task<IActionResult> Create([FromBody] CreateComentarioDto dto)
            {
                var novo = await _comentarioService.CriarAsync(dto);
                return Ok(novo);
            }

            [Authorize]
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var sucesso = await _comentarioService.RemoverAsync(id);
                return sucesso ? NoContent() : NotFound();
            }
        }
    }
}
