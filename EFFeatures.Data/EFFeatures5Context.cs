using EFFeatures.Models.Entities.EFFeatures5;
using System.Data.Entity;

namespace EFFeatures.Data
{
    public class EFFeatures5Context : DbContext
    {
        public EFFeatures5Context() : base ("DbConnection5") { }

        public DbSet<Hypermarket> Hypermarkets { get; set; }
        public DbSet<HypermarketSection> HypermarketSections { get; set; }
    }
}
