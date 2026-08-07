using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaborCia.API.Data;
using SaborCia.API.DTOs;
using SaborCia.API.Models;

namespace SaborCia.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task <IActionResult> GetPrdutos()
        {
            var produtos = await _context.Produtos.ToListAsync();
            return Ok(produtos);
        }

        [HttpPost]
        public async Task<IActionResult> CriarProduto (CriarProduto dto)
        {
            var produtos = new Produtos
            {
                Nome = dto.Nome,
                Preco = dto.Preco,
                Descricao = dto.Descricao,
                Categoria = dto.Categoria
            };

            _context.Produtos.Add(produtos);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPrdutos), new { id = produtos.Id }, produtos);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarProduto(int id, AtualizarProdutoDto dto)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            produto.Nome = dto.Nome;
            produto.Preco = dto.Preco;
            produto.Descricao = dto.Descricao;
            produto.Categoria = dto.Categoria;

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
