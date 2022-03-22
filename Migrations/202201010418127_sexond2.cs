namespace Dept_ItemsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sexond2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.dept2",
                c => new
                    {
                        deptid = c.String(nullable: false, maxLength: 128),
                        deptname = c.String(),
                        location = c.String(),
                    })
                .PrimaryKey(t => t.deptid);
            
            CreateTable(
                "dbo.items2",
                c => new
                    {
                        itemcode = c.String(nullable: false, maxLength: 128),
                        itemname = c.String(),
                        deptid = c.String(maxLength: 128),
                        cost = c.Decimal(precision: 18, scale: 2),
                        rate = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.itemcode)
                .ForeignKey("dbo.dept2", t => t.deptid)
                .Index(t => t.deptid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.items2", "deptid", "dbo.dept2");
            DropIndex("dbo.items2", new[] { "deptid" });
            DropTable("dbo.items2");
            DropTable("dbo.dept2");
        }
    }
}
