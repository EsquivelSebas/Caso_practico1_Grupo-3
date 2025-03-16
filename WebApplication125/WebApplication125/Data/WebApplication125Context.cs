using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication125.Models;

namespace WebApplication125.Data
{
    public class WebApplication125Context : DbContext
    {
        public WebApplication125Context (DbContextOptions<WebApplication125Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication125.Models.HistorialModels> HistorialModels { get; set; } = default!;
    }
}
