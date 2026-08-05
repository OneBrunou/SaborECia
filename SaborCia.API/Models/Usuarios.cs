namespace SaborCia.API.Models
{
    public enum RoleUsuario
    {
        Admin,
        Atendente
    }
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public  RoleUsuario RoleUsuario { get; set; }
        public DateTime CriadoEm { get; set; }
        public int IdUnidade { get; set; } = 0;
        public Unidades Unidade { get; set; } = null!;

        public ICollection<Pedidos> Pedidos { get; set; } = new List<Pedidos>();
    }
}
