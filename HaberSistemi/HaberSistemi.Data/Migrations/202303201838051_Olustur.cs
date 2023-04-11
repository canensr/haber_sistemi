namespace HaberSistemi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Olustur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Haber",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Baslik = c.String(maxLength: 200),
                        KisaAciklama = c.String(),
                        Aciklama = c.String(),
                        AktifMi = c.Boolean(nullable: false),
                        EklemeTarihi = c.DateTime(nullable: false),
                        Resim = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Resim",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Haber_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Haber", t => t.Haber_ID)
                .Index(t => t.Haber_ID);
            
            CreateTable(
                "dbo.Kullanici",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdSoyad = c.String(maxLength: 100),
                        Email = c.String(nullable: false),
                        Sifre = c.String(nullable: false, maxLength: 16),
                        KayitTarihi = c.DateTime(nullable: false),
                        Aktif = c.Boolean(nullable: false),
                        Rol_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Rol", t => t.Rol_ID)
                .Index(t => t.Rol_ID);
            
            CreateTable(
                "dbo.Rol",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RolAdi = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kullanici", "Rol_ID", "dbo.Rol");
            DropForeignKey("dbo.Resim", "Haber_ID", "dbo.Haber");
            DropIndex("dbo.Kullanici", new[] { "Rol_ID" });
            DropIndex("dbo.Resim", new[] { "Haber_ID" });
            DropTable("dbo.Rol");
            DropTable("dbo.Kullanici");
            DropTable("dbo.Resim");
            DropTable("dbo.Haber");
        }
    }
}
