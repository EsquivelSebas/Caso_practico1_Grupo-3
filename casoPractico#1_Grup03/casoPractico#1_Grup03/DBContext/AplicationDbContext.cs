using System.Collections.Generic;
using casoPractico_1_Grup03.Models;
using Microsoft.EntityFrameworkCore;

namespace casoPractico_1_Grup03.DBContext
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }

        // Define DbSets for your entities
        //just define the name of the set with an s at the end
        //doesn't matter if the name isn't proper english.


        public DbSet<Usuarios> G3Usuario { get; set; }

        public DbSet<Historial> G3Historial { get; set; }

        public DbSet<Videojuego> G3Videojuego { get; set; }
    }
}
