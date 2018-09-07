using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KosarkaMVC.Models
{
    [Table("dbo.Ekipe")]
    public class Ekipa
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Sezona { get; set; }
        public string Trener { get; set; }
        public int BrojBodova { get; set; }
        public int BrojPobeda { get; set; }
        public int BrojPoraza { get; set; }
        public double ProcenatUspesnosti { get; set; }
        public int PostignutiPoeni { get; set; }
        public int PrimljeniPoeni { get; set; }
        public int KosRazlika { get; set; }

        public IList<Igrac> Igraci { get; set; }
    }
}