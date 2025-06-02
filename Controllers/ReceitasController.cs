using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project1_Angular.Data;
using Project1_Angular.Models;

namespace Project1_Angular.Controllers
{
    //[Authorize(AuthenticationSchemes = "Identity.Application")]
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReceitasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Receitas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receita>>> GetReceitas()
        {
          if (_context.Receitas == null)
          {
              return NotFound();
          }
            return await _context.Receitas
            .Include(r => r.Ingredientes)
            .ThenInclude(ir => ir.Ingrediente)
            .Include(r => r.Comentarios)
            .Include(r => r.Utilizador)
            .ToListAsync();
        }

        // GET: api/Receitas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Receita>> GetReceita(int id)
        {
          if (_context.Receitas == null)
          {
              return NotFound();
          }
            var receita = await _context.Receitas
          .Include(r => r.Ingredientes)
          .ThenInclude(ir => ir.Ingrediente)
          .Include(r => r.Comentarios)
          .Include(r => r.Utilizador)
          .FirstOrDefaultAsync(r => r.ReceitaId == id);

            if (receita == null)
            {
                return NotFound();
            }

            return receita;
        }

        // PUT: api/Receitas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceita(int id, Receita receita)
        {
            if (id != receita.ReceitaId)
            {
                return BadRequest();
            }

            _context.Entry(receita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceitaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Receitas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostReceita(Receita receita)
        {
            //var userName = "testuser"; // ⬅️ Replace with a test user name
            //var utilizador = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);

            //if (utilizador == null)
            //    return Unauthorized();

            // Prepara a lista de ingredientes finais
            var novaLista = new List<IngredienteReceita>();

            foreach (var ir in receita.Ingredientes)
            {
                if (string.IsNullOrWhiteSpace(ir.Ingrediente?.Nome))
                    continue;

                // Verifica se o ingrediente já existe pelo nome
                var ingredienteExistente = await _context.Ingredientes
                    .FirstOrDefaultAsync(i => i.Nome.ToLower() == ir.Ingrediente.Nome.ToLower());

                if (ingredienteExistente == null)
                {
                    ingredienteExistente = new Ingrediente
                    {
                        Nome = ir.Ingrediente.Nome,
                        Unidade = ir.Ingrediente.Unidade
                    };
                    _context.Ingredientes.Add(ingredienteExistente);
                    await _context.SaveChangesAsync(); // importante para gerar o Id
                }

                novaLista.Add(new IngredienteReceita
                {
                    Quantidade = ir.Quantidade,
                    Ingrediente = ingredienteExistente
                });
            }

            receita.Ingredientes = novaLista;

            _context.Receitas.Add(receita);
            await _context.SaveChangesAsync();

            return Ok(receita);
        }

        // DELETE: api/Receitas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceita(int id)
        {
            if (_context.Receitas == null)
            {
                return NotFound();
            }
            var receita = await _context.Receitas.FindAsync(id);
            if (receita == null)
            {
                return NotFound();
            }

            _context.Receitas.Remove(receita);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReceitaExists(int id)
        {
            return (_context.Receitas?.Any(e => e.ReceitaId == id)).GetValueOrDefault();
        }
    }
}
