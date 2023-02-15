using Biblioteca.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Biblioteca.Persistencia
{
    public class ContextoLibro : DbContext
    {
        public ContextoLibro(DbContextOptions<ContextoLibro> options) : base(options)
        {
        }

        public DbSet<Libro> Libro { get; set; }
    }
}
