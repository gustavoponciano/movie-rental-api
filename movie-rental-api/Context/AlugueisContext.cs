using Microsoft.EntityFrameworkCore;
using movie_rental_api.Entities;

namespace movie_rental_api.Context
{
    public class AlugueisContext : DbContext
    {
        public AlugueisContext(DbContextOptions<AlugueisContext> options) : base(options) 
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Filme> Filmes { get; set; }
    }
}
