using BeerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeerService.Data.Contexts
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options) { }
        public DbSet<Cerveja> Cervejas { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
    }
}
