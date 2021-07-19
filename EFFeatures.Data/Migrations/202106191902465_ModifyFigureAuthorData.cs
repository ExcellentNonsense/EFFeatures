namespace EFFeatures.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyFigureAuthorData : DbMigration
    {
        #region Default generated code.
        //public override void Up()
        //{
        //    AddColumn("dbo.Figures", "AuthorFullName", c => c.String());
        //    DropColumn("dbo.Figures", "AuthorFirstName");
        //    DropColumn("dbo.Figures", "AuthorLastName");
        //}

        //public override void Down()
        //{
        //    AddColumn("dbo.Figures", "AuthorLastName", c => c.String());
        //    AddColumn("dbo.Figures", "AuthorFirstName", c => c.String());
        //    DropColumn("dbo.Figures", "AuthorFullName");
        //}
        #endregion

        public override void Up()
        {
            AddColumn("dbo.Figures", "AuthorFullName", c => c.String());

            Sql(
            @"
                UPDATE dbo.Figures
                SET AuthorFullName = AuthorFirstName + ' ' + AuthorLastName;
            ");

            DropColumn("dbo.Figures", "AuthorFirstName");
            DropColumn("dbo.Figures", "AuthorLastName");
        }

        public override void Down()
        {
            AddColumn("dbo.Figures", "AuthorLastName", c => c.String());
            AddColumn("dbo.Figures", "AuthorFirstName", c => c.String());

            Sql(
            @"
                UPDATE dbo.Figures
                SET
                AuthorFirstName = SUBSTRING(AuthorFullName, 1, CHARINDEX(' ', AuthorFullName) - 1),
                AuthorLastName = SUBSTRING(AuthorFullName, CHARINDEX(' ', AuthorFullName) + 1, LEN(AuthorFullName))
            ");

            DropColumn("dbo.Figures", "AuthorFullName");
        }
    }
}
