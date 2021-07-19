namespace EFFeatures.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFigureType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Figures", "Tipe", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Figures", "Tipe");
        }
    }
}
