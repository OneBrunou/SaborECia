using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaborCia.API.Data;

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
    }
   
}
