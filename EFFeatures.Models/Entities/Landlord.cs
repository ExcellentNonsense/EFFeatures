using System.Collections.Generic;

namespace EFFeatures.Models.Entities
{
    public class Landlord
    {
        public int LandlordId { get; set; }
        public string FullName { get; set; }
        public ICollection<House> LandlordFirstFor { get; set; }
        public ICollection<House> LandlordSecondFor { get; set; }
    }
}
