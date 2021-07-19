using System.Data.Entity;

namespace EFFeatures.Data
{
    public class EFFeaturesDbInitializer : DropCreateDatabaseAlways<EFFeaturesContext>
    {
        protected override void Seed(EFFeaturesContext context)
        {
            context.Database.ExecuteSqlCommand("CREATE INDEX IX_Books_Title ON Books (Title)");
        }
    }
}
