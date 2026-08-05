namespace SaborCia.API.Models
{
    public class Unidades
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;

        public ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
        public ICollection<Pedidos> Pedidos{ get; set; } = new List<Pedidos>();
        public ICollection<Estoque> Estoque { get; set; } = new List<Estoque>();

    }
}
