using System.Collections.ObjectModel;

namespace SaborCia.API.Models
{
    public class Estoque
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public int IdProdutos { get; set; } = 0;
        public Produtos Produto { get; set; } = null!;
        public int IdUnidade { get; set; } = 0;
        public Unidades Unidade { get; set; } = null!;
    }
}
