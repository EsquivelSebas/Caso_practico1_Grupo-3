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
        // public DbSet<YourEntity> YourEntities { get; set; }
    }
}
