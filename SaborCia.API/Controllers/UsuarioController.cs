using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using BCrypt.Net;
using SaborCia.API.Data;
using SaborCia.API.DTOs;
using SaborCia.API.Models;

namespace SaborCia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return Ok(usuarios);
        }
        [HttpPost]
        public async Task<IActionResult> CriarUsuario(CriarUsuarioDto dto)
        {
            var usuario = new Usuarios
            {
                Nome = dto.Nome,
                Email = dto.Email,
                SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha),
                RoleUsuario = Enum.Parse<RoleUsuario>(dto.RoleUsuario),
                IdUnidade = dto.IdUnidade,
                CriadoEm = DateTime.Now
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuarios), new { id = usuario.Id }, usuario);
        }

        [HttpPut ("{id")]
        public async Task<IActionResult> AtualizarUsuario (int id, AtualizarUsuarioDto dto)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            usuario.Nome = dto.Nome;
            usuario.Email = dto.Email;
            usuario.RoleUsuario = Enum.Parse<RoleUsuario>(dto.RoleUsuario);
            usuario.IdUnidade = dto.IdUnidade;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}/senha")]
        public async Task<IActionResult> AlterarSenha(int id, AlteraSenha dto)
        {
            var usuario = await _context.Usuarios.FindAsync();
            if (usuario == null)
            {
                return NotFound();
            }

            bool senhaCorreta = BCrypt.Net.BCrypt.Verify(dto.SenhaAtual, usuario.SenhaHash);

            if(!senhaCorreta)
            {
                return BadRequest("Senha atual Incorreta.");
            }

            usuario.SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.SenhaNova);

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
