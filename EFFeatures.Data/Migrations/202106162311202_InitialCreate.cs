namespace EFFeatures.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Angles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Degree = c.Double(nullable: false),
                        Side1Length = c.Double(nullable: false),
                        Side2Length = c.Double(nullable: false),
                        Figure_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Figures", t => t.Figure_Id)
                .Index(t => t.Figure_Id);
            
            CreateTable(
                "dbo.Figures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Angles", "Figure_Id", "dbo.Figures");
            DropIndex("dbo.Angles", new[] { "Figure_Id" });
            DropTable("dbo.Figures");
            DropTable("dbo.Angles");
        }
    }
}
