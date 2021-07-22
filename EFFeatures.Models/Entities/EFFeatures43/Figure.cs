using System.Collections.Generic;

namespace EFFeatures.Models.Entities.EFFeatures43
{
    public class Figure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string AuthorFullName { get; set; }

        public ICollection<Angle> Angles { get; set; }
    }
}
