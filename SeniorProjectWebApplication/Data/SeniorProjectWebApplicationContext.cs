using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SeniorProjectWebApplication.Data
{
    public class SeniorProjectWebApplicationContext : DbContext
    {
        public SeniorProjectWebApplicationContext (DbContextOptions<SeniorProjectWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<SeniorProjectWebApplication.Data.Measurement> Measurement { get; set; }
    }
}
