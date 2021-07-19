using System.ComponentModel.DataAnnotations.Schema;

namespace EFFeatures.Models.Entities
{
    public class Recipient
    {
        [Column("RecipientFirstName")]
        public string FirstName { get; set; }
        [Column("RecipientLastName")]
        public string LastName { get; set; }
        [Column("RecipientAddress")]
        public string Address { get; set; }
    }
}
