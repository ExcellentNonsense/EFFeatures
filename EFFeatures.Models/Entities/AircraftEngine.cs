using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFFeatures.Models.Entities
{
    [Table("AircraftEngine")]
    public class AircraftEngine
    {
        public int AircraftEngineId { get; set; }
        public string Title { get; set; }
        public DateTime FirstRelease { get; set; }

        [Required]
        public AircraftEngineSpecs AircraftEngineSpecs { get; set; }
    }
}
