using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project1_Angular.DTOs;
using Project1_Angular.Services;

namespace Project1_Angular.Controllers
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
                var comentarios = await _comentarioService.GetComentariosByReceitaIdAsync(receitaId);
                return Ok(comentarios);
            }

            [Authorize]
            [HttpPost]
            public async Task<IActionResult> Create([FromBody] ComentarioCreateDto dto)
            {
                var novo = await _comentarioService.CreateComentarioAsync(dto);
                return Ok(novo);
            }

            [Authorize]
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var sucesso = await _comentarioService.DeleteComentarioAsync(id);
                return sucesso ? NoContent() : NotFound();
            }
        }

}

