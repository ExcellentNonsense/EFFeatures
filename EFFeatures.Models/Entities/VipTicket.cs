namespace EFFeatures.Models.Entities
{
    // [Table("VipTickets")] // Commented: Table Per Type. Not commented: Table Per Hierarchy.
    public class VipTicket : Ticket
    {
        public int MemberId { get; set; }
    }
}
