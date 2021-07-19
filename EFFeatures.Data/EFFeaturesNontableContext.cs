using System.Data.Entity;

namespace EFFeatures.Data
{
    public class EFFeaturesNontableContext : DbContext
    {
        public EFFeaturesNontableContext() : base("DbConnectionNontable") { }
    }
}
