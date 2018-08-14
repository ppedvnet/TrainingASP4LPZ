namespace EFCodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmp : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employees", name: "Occupation", newName: "Job");
            AlterColumn("dbo.Employees", "Job", c => c.String(maxLength: 27));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Job", c => c.String());
            RenameColumn(table: "dbo.Employees", name: "Job", newName: "Occupation");
        }
    }
}
