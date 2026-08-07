using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SaborCia.API.Data;
using SaborCia.API.DTOs;
using SaborCia.API.Models;

namespace SaborCia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnidadesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UnidadesController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetUnidades()
        {
            var unidades = await _context.Unidades.ToListAsync();
            return Ok(unidades);
        }

        [HttpPost]
        public async Task<IActionResult> CriarUnidade(CriarUnidadeDto dto)
        {
            var unidade = new Unidades
            {
                Nome = dto.Nome,
                Endereco = dto.Endereco
            };

            _context.Unidades.Add(unidade);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUnidades), new { id = unidade.Id }, unidade);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarUnidade(int id, AtualizarUnidade dto)
        {
            var unidade = await _context.Unidades.FindAsync(id);

            if (unidade == null)
            {
                return NotFound();
            }

            unidade.Nome = dto.Nome;
            unidade.Endereco = dto.Endereco;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarUnidade(int id)
        {
            var unidade = await _context.Unidades.FindAsync(id);

            if (unidade == null)
            {
                return NotFound();

            }

            _context.Unidades.Remove(unidade);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
   
}
