namespace Dept_ItemsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaa2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.items2", "date", c => c.DateTime(nullable: false));
            AddColumn("dbo.items2", "picture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.items2", "picture");
            DropColumn("dbo.items2", "date");
        }
    }
}
