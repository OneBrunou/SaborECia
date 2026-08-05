namespace SaborCia.API.Models
{
    public class ItemPedidos
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int IdProdutos { get; set; } = 0;
        public Produtos Produto { get; set; } = null!;
        public int IdPedidos { get; set; } = 0;
        public Pedidos Pedido { get; set; } = null!;
    }
}
