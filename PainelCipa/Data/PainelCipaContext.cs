using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PainelCipa.Models
{
    public class PainelCipaContext : DbContext
    {
        public PainelCipaContext (DbContextOptions<PainelCipaContext> options) : base(options)
        {
        }

        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Election> Election { get; set; }
        public DbSet<Vote> Vote { get; set; }        
    }
}
