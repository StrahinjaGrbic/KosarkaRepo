namespace KosarkaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ekipe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Sezona = c.String(),
                        Trener = c.String(),
                        BrojBodova = c.Int(nullable: false),
                        BrojPobeda = c.Int(nullable: false),
                        BrojPoraza = c.Int(nullable: false),
                        ProcenatUspesnosti = c.Double(nullable: false),
                        PostignutiPoeni = c.Int(nullable: false),
                        PrimljeniPoeni = c.Int(nullable: false),
                        KosRazlika = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Igraci",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Visina = c.Int(nullable: false),
                        Tezina = c.Int(nullable: false),
                        Godiste = c.Int(nullable: false),
                        EkipaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ekipe", t => t.EkipaId, cascadeDelete: true)
                .Index(t => t.EkipaId);
            
            CreateTable(
                "dbo.Statistike",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UtakmicaId = c.Int(nullable: false),
                        IgracId = c.Int(nullable: false),
                        BrojDresa = c.Int(nullable: false),
                        Minutaza = c.Int(nullable: false),
                        TwoptA = c.Int(nullable: false),
                        TwoptM = c.Int(nullable: false),
                        ThreeptA = c.Int(nullable: false),
                        ThreeptM = c.Int(nullable: false),
                        FtA = c.Int(nullable: false),
                        FtM = c.Int(nullable: false),
                        OReb = c.Int(nullable: false),
                        DReb = c.Int(nullable: false),
                        Reb = c.Int(nullable: false),
                        Ast = c.Int(nullable: false),
                        To = c.Int(nullable: false),
                        Stl = c.Int(nullable: false),
                        Blk = c.Int(nullable: false),
                        Pts = c.Int(nullable: false),
                        Fd = c.Int(nullable: false),
                        Fc = c.Int(nullable: false),
                        Pir = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Igraci", t => t.IgracId, cascadeDelete: true)
                .ForeignKey("dbo.Utakmice", t => t.UtakmicaId, cascadeDelete: true)
                .Index(t => t.UtakmicaId)
                .Index(t => t.IgracId);
            
            CreateTable(
                "dbo.Utakmice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sezona = c.String(),
                        Kolo = c.String(),
                        Datum = c.DateTime(nullable: false),
                        EkipaAId = c.Int(nullable: false),
                        EkipaBId = c.Int(nullable: false),
                        Sudija1Id = c.Int(nullable: false),
                        Sudija2Id = c.Int(nullable: false),
                        Sudija3Id = c.Int(nullable: false),
                        RezultatA = c.Int(nullable: false),
                        RezultatB = c.Int(nullable: false),
                        Sudija_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ekipe", t => t.EkipaAId, cascadeDelete: false)
                .ForeignKey("dbo.Ekipe", t => t.EkipaBId, cascadeDelete: false)
                .ForeignKey("dbo.Sudije", t => t.Sudija_Id)
                .ForeignKey("dbo.Sudije", t => t.Sudija1Id, cascadeDelete: false)
                .ForeignKey("dbo.Sudije", t => t.Sudija2Id, cascadeDelete: false)
                .ForeignKey("dbo.Sudije", t => t.Sudija3Id, cascadeDelete: false)
                .Index(t => t.EkipaAId)
                .Index(t => t.EkipaBId)
                .Index(t => t.Sudija1Id)
                .Index(t => t.Sudija2Id)
                .Index(t => t.Sudija3Id)
                .Index(t => t.Sudija_Id);
            
            CreateTable(
                "dbo.Sudije",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Utakmice", "Sudija3Id", "dbo.Sudije");
            DropForeignKey("dbo.Utakmice", "Sudija2Id", "dbo.Sudije");
            DropForeignKey("dbo.Utakmice", "Sudija1Id", "dbo.Sudije");
            DropForeignKey("dbo.Utakmice", "Sudija_Id", "dbo.Sudije");
            DropForeignKey("dbo.Statistike", "UtakmicaId", "dbo.Utakmice");
            DropForeignKey("dbo.Utakmice", "EkipaBId", "dbo.Ekipe");
            DropForeignKey("dbo.Utakmice", "EkipaAId", "dbo.Ekipe");
            DropForeignKey("dbo.Statistike", "IgracId", "dbo.Igraci");
            DropForeignKey("dbo.Igraci", "EkipaId", "dbo.Ekipe");
            DropIndex("dbo.Utakmice", new[] { "Sudija_Id" });
            DropIndex("dbo.Utakmice", new[] { "Sudija3Id" });
            DropIndex("dbo.Utakmice", new[] { "Sudija2Id" });
            DropIndex("dbo.Utakmice", new[] { "Sudija1Id" });
            DropIndex("dbo.Utakmice", new[] { "EkipaBId" });
            DropIndex("dbo.Utakmice", new[] { "EkipaAId" });
            DropIndex("dbo.Statistike", new[] { "IgracId" });
            DropIndex("dbo.Statistike", new[] { "UtakmicaId" });
            DropIndex("dbo.Igraci", new[] { "EkipaId" });
            DropTable("dbo.Sudije");
            DropTable("dbo.Utakmice");
            DropTable("dbo.Statistike");
            DropTable("dbo.Igraci");
            DropTable("dbo.Ekipe");
        }
    }
}
