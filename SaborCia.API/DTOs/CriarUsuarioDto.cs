namespace SaborCia.API.DTOs
{
    public class CriarUsuarioDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Seenha { get; set; } = string.Empty;
        public string RoleUsuario { get; set; } = string.Empty;
        public int IdUnidade { get; set; }
    }
}
