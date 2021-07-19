using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFFeatures.Models.Entities
{
    [Table("AircraftEngine")]
    public class AircraftEngineSpecs
    {
        [Key, ForeignKey("AircraftEngine")]
        public int AircraftEngineId { get; set; }
        public int StaticThrust { get; set; }
        public int AirConsumption { get; set; }
        public float BypassRatio { get; set; }
        public float CompressorPressureRise { get; set; }

        public AircraftEngine AircraftEngine { get; set; }
    }
}
