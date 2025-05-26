using Microsoft.AspNetCore.Mvc;
using Project1_Angular.Services;
using Project1_Angular.DTOs;

namespace Project1_Angular.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class UtilizadoresController : ControllerBase
        {
            private readonly IUtilizadorService _utilizadorService;

            public UtilizadoresController(IUtilizadorService utilizadorService)
            {
                _utilizadorService = utilizadorService;
            }

            [HttpPost("register")]
            public async Task<IActionResult> Register([FromBody] RegisterDto dto)
            {
                var resultado = await _utilizadorService.RegisterUserAsync(dto);
                return resultado.Sucess ? Ok(resultado) : BadRequest(resultado.Message);
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login([FromBody] LoginDto dto)
            {
                var token = await _utilizadorService.LoginAsync(dto);
                return token == null ? Unauthorized("Credenciais inválidas.") : Ok(new { Token = token });
            }

            
        }
 }

