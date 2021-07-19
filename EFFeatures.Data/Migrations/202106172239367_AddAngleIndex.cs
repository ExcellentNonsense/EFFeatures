namespace EFFeatures.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAngleIndex : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Angles", "Index", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Angles", "Index");
        }
    }
}
