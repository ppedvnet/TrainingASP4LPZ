namespace EFCodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerNumber = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        Name = c.String(),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Occupation = c.String(),
                        Name = c.String(),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DepartmentEmployees",
                c => new
                    {
                        Department_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Department_Id, t.Employee_Id })
                .ForeignKey("dbo.Departments", t => t.Department_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.Department_Id)
                .Index(t => t.Employee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DepartmentEmployees", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.DepartmentEmployees", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.Clients", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.DepartmentEmployees", new[] { "Employee_Id" });
            DropIndex("dbo.DepartmentEmployees", new[] { "Department_Id" });
            DropIndex("dbo.Clients", new[] { "EmployeeId" });
            DropTable("dbo.DepartmentEmployees");
            DropTable("dbo.Departments");
            DropTable("dbo.Employees");
            DropTable("dbo.Clients");
        }
    }
}
