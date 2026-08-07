using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaborCia.API.Data;

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
    }
}
