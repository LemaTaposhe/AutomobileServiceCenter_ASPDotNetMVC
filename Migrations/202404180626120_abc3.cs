namespace MvcProject_Lema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 11),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
