using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project1_Angular.Services;
using Project1_Angular.DTOs;

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
                var receitas = await _receitaService.GetAllReceitasAsync();
                return Ok(receitas);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var receita = await _receitaService.GetReceitaByIdAsync(id);
                return receita == null ? NotFound() : Ok(receita);
            }

            [Authorize]
            [HttpPost]
            public async Task<IActionResult> Create([FromBody] ReceitaCreateDto dto)
            {
                var novaReceita = await _receitaService.CreateReceitaAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = novaReceita.Id }, novaReceita);
            }

            [Authorize]
            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, [FromBody] ReceitaUpdateDto dto)
            {
                var resultado = await _receitaService.UpdateReceitaAsync(id, dto);
                return resultado ? NoContent() : NotFound();
            }

            [Authorize]
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var resultado = await _receitaService.DeleteReceitaAsync(id);
                return resultado ? NoContent() : NotFound();
            }
        }
 }

