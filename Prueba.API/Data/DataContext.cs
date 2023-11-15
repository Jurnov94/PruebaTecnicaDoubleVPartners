using Microsoft.EntityFrameworkCore;
using Prueba.Shared.Entities;
using System.ComponentModel.DataAnnotations;

namespace Prueba.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Persona> Persona { get; set; }
        public DbSet<Usuario> Usuario { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



        }
    }
}
