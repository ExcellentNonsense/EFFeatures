using System.Data.Entity.Spatial;

namespace EFFeatures.Models.Entities.EFFeatures5
{
    public class Hypermarket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DbGeography Location { get; set; }
    }
}
