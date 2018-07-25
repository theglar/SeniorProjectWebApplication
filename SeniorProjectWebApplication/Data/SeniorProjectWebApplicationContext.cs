using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SeniorProjectWebApplication.Models
{
    public class SeniorProjectWebApplicationContext : DbContext
    {
        public SeniorProjectWebApplicationContext (DbContextOptions<SeniorProjectWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<SeniorProjectWebApplication.Models.Measurement> Measurement { get; set; }
    }
}
