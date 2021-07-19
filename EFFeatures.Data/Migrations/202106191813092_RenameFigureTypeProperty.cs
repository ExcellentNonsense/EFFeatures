namespace EFFeatures.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameFigureTypeProperty : DbMigration
    {
        #region Default generated code.
        //public override void Up()
        //{
        //    AddColumn("dbo.Figures", "Type", c => c.String());
        //    DropColumn("dbo.Figures", "Tipe");
        //}

        //public override void Down()
        //{
        //    AddColumn("dbo.Figures", "Tipe", c => c.String());
        //    DropColumn("dbo.Figures", "Type");
        //}
        #endregion

        public override void Up()
        {
            RenameColumn("dbo.Figures", "Tipe", "Type");
        }

        public override void Down()
        {
            RenameColumn("dbo.Figures", "Type", "Tipe");
        }
    }
}
