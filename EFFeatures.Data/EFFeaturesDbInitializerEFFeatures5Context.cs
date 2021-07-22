using EFFeatures.Models.Entities.EFFeatures5;
using System.Data.Entity;
using System.Data.Entity.Spatial;

namespace EFFeatures.Data
{
    public class EFFeaturesDbInitializerEFFeatures5Context : DropCreateDatabaseAlways<EFFeatures5Context>
    {
        protected override void Seed(EFFeatures5Context context)
        {
            context.Hypermarkets.Add(new Hypermarket
            {
                Name = "Tesco",
                Location = DbGeography.FromText("POINT(-122.336106 47.605049)")
            });

            context.Hypermarkets.Add(new Hypermarket
            {
                Name = "Morrisons",
                Location = DbGeography.FromText("POINT(-122.335197 47.646711)")
            });
        }
    }
}
