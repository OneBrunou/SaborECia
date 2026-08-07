namespace SaborCia.API.DTOs
{
    public class AtualizarUsuarioDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string RoleUsuario { get; set; } = string.Empty;
        public int IdUnidade { get; set; }
    }
}
