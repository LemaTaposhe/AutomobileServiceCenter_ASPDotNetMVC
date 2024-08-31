namespace MvcProject_Lema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeVMs",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeeVMs");
        }
    }
}
