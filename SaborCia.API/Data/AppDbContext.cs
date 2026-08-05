using Microsoft.EntityFrameworkCore;
using SaborCia.API.Models;

namespace SaborCia.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Unidades> Unidades { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<ItemPedidos> ItemPedidos { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
    }

    
}
