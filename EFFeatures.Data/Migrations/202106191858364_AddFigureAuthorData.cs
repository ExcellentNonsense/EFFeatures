namespace EFFeatures.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFigureAuthorData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Figures", "AuthorFirstName", c => c.String());
            AddColumn("dbo.Figures", "AuthorLastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Figures", "AuthorLastName");
            DropColumn("dbo.Figures", "AuthorFirstName");
        }
    }
}
