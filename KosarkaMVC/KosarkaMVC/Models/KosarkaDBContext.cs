using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KosarkaMVC.Models
{
    public class KosarkaDBContext : DbContext
    {
        public KosarkaDBContext() : base("name=KosarkaDBContext")
        {

        }

        public DbSet<Igrac> Igraci { get; set; }
        public DbSet<Sudija> Sudije { get; set; }
        public DbSet<Ekipa> Ekipe { get; set; }
        public DbSet<Utakmica> Utakmice { get; set; }
        public DbSet<Statistika> Statistike { get; set; }
    }
}