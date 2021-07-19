namespace EFFeatures.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration43 : DbMigrationsConfiguration<EFFeatures.Data.EFFeatures43Context>
    {
        public Configuration43()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EFFeatures.Data.EFFeatures43Context";
        }

        protected override void Seed(EFFeatures.Data.EFFeatures43Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
