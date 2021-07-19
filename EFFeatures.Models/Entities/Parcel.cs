using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFFeatures.Models.Entities
{
    public class Parcel
    {
        public Parcel()
        {
            Recipient = new Recipient();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ParcelId { get; set; }
        public float Weight { get; set; }
        public Recipient Recipient { get; set; }
    }
}
