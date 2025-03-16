using System.Collections.Generic;
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
        public DbSet<Historial> Historials { get; set; }
    }
}
