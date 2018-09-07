using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KosarkaMVC.Models
{
    [Table("dbo.Statistike")]
    public class Statistika
    {
        public int Id { get; set; }

        public int UtakmicaId { get; set; }
        public Utakmica Utakmica { get; set; }

        public int IgracId { get; set; }
        public Igrac Igrac { get; set; }

        public int BrojDresa { get; set; }
        public int Minutaza { get; set; }
        public int TwoptA { get; set; }
        public int TwoptM { get; set; }
        public int ThreeptA { get; set; }
        public int ThreeptM { get; set; }
        public int FtA { get; set; }
        public int FtM { get; set; }
        public int OReb { get; set; }
        public int DReb { get; set; }
        public int Reb { get; set; }
        public int Ast { get; set; }
        public int To { get; set; }
        public int Stl { get; set; }
        public int Blk { get; set; }
        public int Pts { get; set; }
        public int Fd { get; set; }
        public int Fc { get; set; }
        public int Pir { get; set; }
    }
}