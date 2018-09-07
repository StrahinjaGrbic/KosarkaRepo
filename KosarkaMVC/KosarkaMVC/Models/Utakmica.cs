using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KosarkaMVC.Models
{
    [Table("dbo.Utakmice")]
    public class Utakmica
    {
        public int Id { get; set; }
        public string Sezona { get; set; }
        public string Kolo { get; set; }
        public DateTime Datum { get; set; }

        public int EkipaAId { get; set; }
        public Ekipa EkipaA { get; set; }

        public int EkipaBId { get; set; }
        public Ekipa EkipaB { get; set; }

        public int Sudija1Id { get; set; }
        public Sudija Sudija1 { get; set; }

        public int Sudija2Id { get; set; }
        public Sudija Sudija2 { get; set; }

        public int Sudija3Id { get; set; }
        public Sudija Sudija3 { get; set; }

        public int RezultatA { get; set; }
        public int RezultatB { get; set; }

        public IList<Statistika> Statistike { get; set; }
    }
}