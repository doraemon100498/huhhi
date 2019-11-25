namespace WindowsFormsApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class khoitaodb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LienHes",
                c => new
                    {
                        TenGoi = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        SDT = c.String(),
                        DiaChi = c.String(),
                        TenNhom = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TenGoi)
                .ForeignKey("dbo.Nhoms", t => t.TenNhom)
                .Index(t => t.TenNhom);
            
            CreateTable(
                "dbo.Nhoms",
                c => new
                    {
                        TenNhom = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.TenNhom);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LienHes", "TenNhom", "dbo.Nhoms");
            DropIndex("dbo.LienHes", new[] { "TenNhom" });
            DropTable("dbo.Nhoms");
            DropTable("dbo.LienHes");
        }
    }
}
