using System.Data.Entity;

namespace EFFeatures.Data
{
    public class EFFeaturesDbInitializerNontableContext : IDatabaseInitializer<EFFeaturesNontableContext>
    {
        public void InitializeDatabase(EFFeaturesNontableContext context)
        {
            // Skip initialization.
            return;

            // Or use: Database.SetInitializer(new NullDatabaseInitializer<EFFeaturesNontableContext>);
        }
    }
}
