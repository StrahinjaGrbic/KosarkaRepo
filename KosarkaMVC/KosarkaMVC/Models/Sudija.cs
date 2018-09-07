using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KosarkaMVC.Models
{
    [Table("dbo.Sudije")]
    public class Sudija
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public IList<Utakmica> Utakmica { get; set; }
    }
}