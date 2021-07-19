using System.ComponentModel.DataAnnotations.Schema;

namespace EFFeatures.Models.Entities
{
    public class House
    {
        public int HouseId { get; set; }
        public string Address { get; set; }
        [InverseProperty("LandlordFirstFor")]
        public Landlord LandlordFirst { get; set; }
        [InverseProperty("LandlordSecondFor")]
        public Landlord LandlordSecond { get; set; }
    }
}
