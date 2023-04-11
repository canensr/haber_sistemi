namespace HaberSistemi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Olustur1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Haber", "Kullanici_ID", c => c.Int());
            AddColumn("dbo.Resim", "ResimUrl", c => c.String());
            AlterColumn("dbo.Haber", "Resim", c => c.String());
            CreateIndex("dbo.Haber", "Kullanici_ID");
            AddForeignKey("dbo.Haber", "Kullanici_ID", "dbo.Kullanici", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Haber", "Kullanici_ID", "dbo.Kullanici");
            DropIndex("dbo.Haber", new[] { "Kullanici_ID" });
            AlterColumn("dbo.Haber", "Resim", c => c.String(maxLength: 200));
            DropColumn("dbo.Resim", "ResimUrl");
            DropColumn("dbo.Haber", "Kullanici_ID");
        }
    }
}
