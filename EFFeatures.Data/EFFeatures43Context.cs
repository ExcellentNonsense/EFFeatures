using EFFeatures.Models.Entities.EFFeatures43;
using System.Data.Entity;

namespace EFFeatures.Data
{
    public class EFFeatures43Context : DbContext
    {
        public EFFeatures43Context() : base ("DbConnection43") { }

        public DbSet<Figure> Figures { get; set; }
        public DbSet<Angle> Angles { get; set; }
    }
}
