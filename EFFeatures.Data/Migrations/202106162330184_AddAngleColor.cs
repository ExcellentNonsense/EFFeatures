namespace EFFeatures.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAngleColor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Angles", "Color", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Angles", "Color");
        }
    }
}
