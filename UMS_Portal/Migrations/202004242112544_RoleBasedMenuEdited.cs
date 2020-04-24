namespace UMS_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleBasedMenuEdited : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetNavigationMenu", "IconClass", c => c.String());
            AddColumn("dbo.AspNetNavigationMenu", "WithoutLinking", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetNavigationMenu", "WithoutLinking");
            DropColumn("dbo.AspNetNavigationMenu", "IconClass");
        }
    }
}
