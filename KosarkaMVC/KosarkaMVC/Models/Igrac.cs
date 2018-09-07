using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KosarkaMVC.Models
{
    [Table("dbo.Igraci")]
    public class Igrac
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Visina { get; set; }
        public int Tezina { get; set; }
        public int Godiste { get; set; }

        public int EkipaId { get; set; }
        public Ekipa Ekipa { get; set; }
        
        public IList<Statistika> Statistike { get; set; }
    }
}