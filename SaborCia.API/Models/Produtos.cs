namespace SaborCia.API.Models
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public string Categoria { get; set; } = string.Empty;

        public ICollection<ItemPedido> ItemPedidos { get; set; } = new List<ItemPedido>();
        public ICollection<Estoque> Estoque { get; set; } = new List<Estoque>();
    }
}
