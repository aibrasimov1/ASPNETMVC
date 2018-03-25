namespace OOADAspNetMVCEFAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Predmet",
                c => new
                    {
                        PredmetId = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        ETCS = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PredmetId);
            
            CreateTable(
                "dbo.UpisNaPredmet",
                c => new
                    {
                        UpisNaPredmetId = c.Int(nullable: false, identity: true),
                        PredmetId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Ocjena = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UpisNaPredmetId)
                .ForeignKey("dbo.Predmet", t => t.PredmetId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.PredmetId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UpisNaPredmet", "StudentId", "dbo.Student");
            DropForeignKey("dbo.UpisNaPredmet", "PredmetId", "dbo.Predmet");
            DropIndex("dbo.UpisNaPredmet", new[] { "StudentId" });
            DropIndex("dbo.UpisNaPredmet", new[] { "PredmetId" });
            DropTable("dbo.Student");
            DropTable("dbo.UpisNaPredmet");
            DropTable("dbo.Predmet");
        }
    }
}
