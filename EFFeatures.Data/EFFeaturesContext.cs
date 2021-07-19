using EFFeatures.Models.Entities;
using System.Data.Common;
using System.Data.Entity;

namespace EFFeatures.Data
{
    public class EFFeaturesContext : DbContext
    {
        public EFFeaturesContext() : base("DbConnection") { }

        public EFFeaturesContext(DbConnection connection) : base(connection, contextOwnsConnection: false) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<AircraftEngine> AircraftEngines { get; set; }
        public DbSet<MobileProviderAccount> MobileProviderAccounts { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(x => x.Authors)
                .WithMany(x => x.Books)
                .Map(x =>
                {
                    x.MapLeftKey("BookId");
                    x.MapRightKey("AuthorId");
                    x.ToTable("BookAuthor");
                });

            modelBuilder.Entity<MobileProviderAccount>()
                .Map(x =>
                {
                    x.Properties(y => new { y.PhoneNumber, y.OwnerFullName });
                    x.ToTable("MobileProviderAccount");
                })
                .Map(x =>
                {
                    x.Properties(y => new { y.SecretWord });
                    x.ToTable("MobileProviderAccountProtectedData");
                });
        }
    }
}
