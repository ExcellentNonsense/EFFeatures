namespace EFFeatures.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmptyMigrationArbitrarySql : DbMigration
    {
        public override void Up()
        {
            Sql(
            @"
                EXEC ('CREATE PROCEDURE getTopNMostComplexFigures
                    @N int
                AS
                    SELECT TOP (@N) F.Name
                    FROM
                    (
                    SELECT A.Figure_Id, COUNT(A.Figure_Id) AS AngelsAmount
                    FROM Angles AS A
                    GROUP BY A.Figure_Id
                    )
                    AS AA
                    LEFT JOIN Figures AS F ON AA.Figure_Id = F.Id
                    ORDER BY AngelsAmount DESC;')
            ");
        }
        
        public override void Down()
        {
            Sql(
            @"
                DROP PROCEDURE dbo.GetTopNMostComplexFigures;
            ");
        }
    }
}
