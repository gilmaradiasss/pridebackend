using Microsoft.EntityFrameworkCore;
using Pride_.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pride_
{
    public class PrideMoreContext : DbContext
    {
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<Pacient> pacients { get; set; }
        public PrideMoreContext(DbContextOptions<PrideMoreContext> options) : base(options)
        {

        }
    }
}
