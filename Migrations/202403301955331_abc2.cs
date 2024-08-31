namespace MvcProject_Lema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppointDetails",
                c => new
                    {
                        AppointDetailId = c.Int(nullable: false, identity: true),
                        AppointMasterId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.AppointDetailId)
                .ForeignKey("dbo.AppointMasters", t => t.AppointMasterId, cascadeDelete: true)
                .Index(t => t.AppointMasterId);
            
            CreateTable(
                "dbo.AppointMasters",
                c => new
                    {
                        AppointMasterId = c.Int(nullable: false, identity: true),
                        AppointDate = c.DateTime(nullable: false),
                        CustomerName = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.AppointMasterId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        categoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            AddColumn("dbo.Services", "ServiceName", c => c.String());
            AddColumn("dbo.Services", "CategoryId", c => c.Int(nullable: false));
            DropColumn("dbo.Services", "Name");
            DropColumn("dbo.Services", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Services", "Name", c => c.String(nullable: false));
            DropForeignKey("dbo.AppointDetails", "AppointMasterId", "dbo.AppointMasters");
            DropIndex("dbo.AppointDetails", new[] { "AppointMasterId" });
            DropColumn("dbo.Services", "CategoryId");
            DropColumn("dbo.Services", "ServiceName");
            DropTable("dbo.Categories");
            DropTable("dbo.AppointMasters");
            DropTable("dbo.AppointDetails");
        }
    }
}
