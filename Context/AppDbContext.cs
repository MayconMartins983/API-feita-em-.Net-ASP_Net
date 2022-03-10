using CRUD_back.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_back.Context
{
    public class AppDbContext : DbContext
    {       
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Clientes> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>().HasData(
            new Clientes {
                Id = 1,
                Name = "Maycon Martins",
                Email = "maycon@gmail.com",
                Tel = 99999999
            },
             new Clientes
             {
                 Id = 2,
                 Name = "Gabi Silva",
                 Email = "Gabi@gmail.com",
                 Tel = 88888888
             },
              new Clientes
              {
                  Id = 3,
                  Name = "Maria Rosa",
                  Email = "Maria@gmail.com",
                  Tel = 99999999
                  
              });
        }

    }
}
