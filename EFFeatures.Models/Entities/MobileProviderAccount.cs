namespace EFFeatures.Models.Entities
{
    public class MobileProviderAccount
    {
        public int MobileProviderAccountId { get; set; }
        public long PhoneNumber { get; set; }
        public string OwnerFullName { get; set; }
        public string SecretWord { get; set; }
    }
}
