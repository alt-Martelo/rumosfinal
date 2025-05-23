using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project1_Angular.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class ReceitasController : ControllerBase
        {
            private readonly IReceitaService _receitaService;

            public ReceitasController(IReceitaService receitaService)
            {
                _receitaService = receitaService;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var receitas = await _receitaService.ObterTodasAsync();
                return Ok(receitas);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var receita = await _receitaService.ObterPorIdAsync(id);
                return receita == null ? NotFound() : Ok(receita);
            }

            [Authorize]
            [HttpPost]
            public async Task<IActionResult> Create([FromBody] ReceitaCreateDTO dto)
            {
                var novaReceita = await _receitaService.CriarAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = novaReceita.Id }, novaReceita);
            }

            [Authorize]
            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, [FromBody] ReceitaCreateDTO dto)
            {
                var resultado = await _receitaService.AtualizarAsync(id, dto);
                return resultado ? NoContent() : NotFound();
            }

            [Authorize]
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var resultado = await _receitaService.RemoverAsync(id);
                return resultado ? NoContent() : NotFound();
            }
        }
 }

