namespace SaborCia.API.DTOs
{
    public class CriarProduto
    {
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set;  }
        public decimal Preco { get; set; }
        public string? Categoria { get; set; }
    }
}
