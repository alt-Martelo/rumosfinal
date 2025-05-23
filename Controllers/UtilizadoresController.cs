using Microsoft.AspNetCore.Mvc;

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
            public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
            {
                var resultado = await _utilizadorService.RegistarAsync(dto);
                return resultado.Sucesso ? Ok(resultado) : BadRequest(resultado.Mensagem);
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login([FromBody] LoginDTO dto)
            {
                var token = await _utilizadorService.AutenticarAsync(dto);
                return token == null ? Unauthorized("Credenciais inválidas.") : Ok(new { Token = token });
            }

            // Pode incluir métodos adicionais para gerir perfil, favoritos, etc.
        }
 }

