using Microsoft.EntityFrameworkCore;
using Filmes2012.Models;

namespace Filmes2012.Data
{
    public class Filmes2012Context : DbContext
    {
        public Filmes2012Context (DbContextOptions<Filmes2012Context> options) : base(options) { }

        public DbSet<Filmes> Filmes { get; set; }
        public DbSet<Filmes2012.Models.Review> Review { get; set; } = default!;
        public DbSet<Filmes2012.Models.Usuario> Usuario { get; set; } = default!;
    }
}