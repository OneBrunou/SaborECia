namespace SaborCia.API.Models
{
    public class Pedidos
    {
        public int Id { get; set; }
        public int Mesa { get; set; }
        public string StatusPedido { get; set; } = string.Empty;
        public DateTime CriadoEm { get; set; }
        public int IdUnidade { get; set; } = 0;
        public Unidades Unidade { get; set; } = null!;
        public int IdUsuario { get; set; } = 0;
        public Usuarios Usuario { get; set; } = null!;
        public ICollection<ItemPedidos> ItemPedidos { get; set; } = new List<ItemPedidos>();
    }
}
