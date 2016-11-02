namespace KompjuterskaOprema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracija : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artiklis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        KataloskiBroj = c.Int(nullable: false),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dobavljacis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FakturaStavkes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(nullable: false),
                        Kolicina = c.Int(nullable: false),
                        Popust = c.Int(nullable: false),
                        CijenaProdaje = c.Double(nullable: false),
                        FakturaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faktures", t => t.FakturaId)
                .Index(t => t.FakturaId);
            
            CreateTable(
                "dbo.Faktures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(nullable: false),
                        KorisnikId = c.Int(),
                        KupacId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisnicis", t => t.KorisnikId)
                .ForeignKey("dbo.Kupcis", t => t.KupacId)
                .Index(t => t.KorisnikId)
                .Index(t => t.KupacId);
            
            CreateTable(
                "dbo.Korisnicis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Email = c.String(),
                        Telefon = c.String(),
                        KorisnickoIme = c.String(),
                        Lozinka = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kupcis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Adresa = c.String(),
                        Email = c.String(),
                        Telefon = c.String(),
                        KorisnickoIme = c.String(),
                        Lozinka = c.String(),
                        TransakcijskiRacun = c.String(),
                        PDVbroj = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PrijemnicaStavkes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Kolicina = c.Int(nullable: false),
                        ArtikalId = c.Int(),
                        PrijemnicaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artiklis", t => t.ArtikalId)
                .ForeignKey("dbo.Prijemnices", t => t.PrijemnicaId)
                .Index(t => t.ArtikalId)
                .Index(t => t.PrijemnicaId);
            
            CreateTable(
                "dbo.Prijemnices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(nullable: false),
                        JedinicnaCijena = c.Double(nullable: false),
                        DobavljacId = c.Int(),
                        KorinsikId = c.Int(),
                        Korisnik_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dobavljacis", t => t.DobavljacId)
                .ForeignKey("dbo.Korisnicis", t => t.Korisnik_Id)
                .Index(t => t.DobavljacId)
                .Index(t => t.Korisnik_Id);
            
            CreateTable(
                "dbo.SkladisteProizvodis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(nullable: false),
                        Kolicina = c.Int(nullable: false),
                        KorisnikId = c.Int(),
                        ArtikalId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artiklis", t => t.ArtikalId)
                .ForeignKey("dbo.Korisnicis", t => t.KorisnikId)
                .Index(t => t.KorisnikId)
                .Index(t => t.ArtikalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SkladisteProizvodis", "KorisnikId", "dbo.Korisnicis");
            DropForeignKey("dbo.SkladisteProizvodis", "ArtikalId", "dbo.Artiklis");
            DropForeignKey("dbo.PrijemnicaStavkes", "PrijemnicaId", "dbo.Prijemnices");
            DropForeignKey("dbo.Prijemnices", "Korisnik_Id", "dbo.Korisnicis");
            DropForeignKey("dbo.Prijemnices", "DobavljacId", "dbo.Dobavljacis");
            DropForeignKey("dbo.PrijemnicaStavkes", "ArtikalId", "dbo.Artiklis");
            DropForeignKey("dbo.FakturaStavkes", "FakturaId", "dbo.Faktures");
            DropForeignKey("dbo.Faktures", "KupacId", "dbo.Kupcis");
            DropForeignKey("dbo.Faktures", "KorisnikId", "dbo.Korisnicis");
            DropIndex("dbo.SkladisteProizvodis", new[] { "ArtikalId" });
            DropIndex("dbo.SkladisteProizvodis", new[] { "KorisnikId" });
            DropIndex("dbo.Prijemnices", new[] { "Korisnik_Id" });
            DropIndex("dbo.Prijemnices", new[] { "DobavljacId" });
            DropIndex("dbo.PrijemnicaStavkes", new[] { "PrijemnicaId" });
            DropIndex("dbo.PrijemnicaStavkes", new[] { "ArtikalId" });
            DropIndex("dbo.Faktures", new[] { "KupacId" });
            DropIndex("dbo.Faktures", new[] { "KorisnikId" });
            DropIndex("dbo.FakturaStavkes", new[] { "FakturaId" });
            DropTable("dbo.SkladisteProizvodis");
            DropTable("dbo.Prijemnices");
            DropTable("dbo.PrijemnicaStavkes");
            DropTable("dbo.Kupcis");
            DropTable("dbo.Korisnicis");
            DropTable("dbo.Faktures");
            DropTable("dbo.FakturaStavkes");
            DropTable("dbo.Dobavljacis");
            DropTable("dbo.Artiklis");
        }
    }
}
