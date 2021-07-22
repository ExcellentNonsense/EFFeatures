using EFFeatures.Data;
using EFFeatures.Models.Entities;
using EFFeatures.Models.Entities.EFFeatures5;
using EFFeatures.Models.NonmodelObjects;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Data.SqlClient;
using System.Linq;

namespace EFFeatures.Console
{
    class Program
    {
        private static void Main(string[] args)
        {
            //CommandInterceptor.Run();

            //Database.SetInitializer(new EFFeaturesDbInitializer());
            //Database.SetInitializer(new EFFeaturesDbInitializerNontableContext());

            //DemoLoadingData();

            //DemoNontableContext();

            //DemoDeleteData();

            //DemoOptimisticConcurrency();

            //DemoCommandInterceptor();

            #region EF 4.3

            //using (var ctx = new EFFeatures43Context())
            //{
            //    ctx.Angles.ToList();
            //}

            #endregion

            #region EF 5

            Database.SetInitializer(new EFFeaturesDbInitializerEFFeatures5Context());

            var myLocation = DbGeography.FromText("POINT(-122.296623 47.640405)");

            var closestHypermarket = GetClosestHypermarket(myLocation);

            #endregion
        }

        private static void DemoLoadingData()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString))
            {
                using (var ctx = new EFFeaturesContext(conn))
                {
                    var authorJL = new Author
                    {
                        FullName = "Jack London"
                    };

                    ctx.Authors.Add(authorJL);

                    ctx.Books.Add(new Book
                    {
                        Title = "The Game",
                        Authors = new[] { authorJL }
                    });

                    ctx.SaveChanges();
                }

                using (var ctx = new EFFeaturesContext(conn))
                {
                    // Lazy Loading.
                    string bookAuthor1 = ctx.Books.First().Authors.First().FullName;

                    // Eager Loading.
                    string bookAuthor2 = ctx.Books
                        .Include(x => x.Authors).First()
                        .Authors.First().FullName;

                    // Explicit Loading.
                    var book = ctx.Books.First();
                    ctx.Entry(book).Collection(x => x.Authors).Load();
                    string bookAuthor3 = book.Authors.First().FullName;
                }
            }
        }

        private static void DemoNontableContext()
        {
            using (var ctx = new EFFeaturesNontableContext())
            {
                var catalogueBooks = ctx.Database
                    .SqlQuery<CatalogueBook>("SELECT * FROM BooksCatalogue")
                    .ToList();

                string bookBindingType = ctx.Database
                    .SqlQuery<string>("GetBookBindingType @p0", "Everyday Cooking Recipes")
                    .FirstOrDefault();
            }
        }

        /// <remarks>
        /// Before running comment out: Author -> [Timestamp] public byte[] Timestamp { get; set; }.
        /// </remarks>
        private static void DemoDeleteData()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString))
            {
                using (var ctx = new EFFeaturesContext(conn))
                {
                    ctx.Authors.AddRange(new[]
                        {
                        new Author { FullName = "Author1" },
                        new Author { FullName = "Author2" },
                        new Author { FullName = "Author3" },
                        new Author { FullName = "Author4" },
                    });

                    ctx.SaveChanges();
                }

                using (var ctx = new EFFeaturesContext(conn))
                {
                    int authorsNumber = ctx.Authors.Count();

                    var author1 = ctx.Authors
                        .Where(x => x.FullName.Equals("Author1", System.StringComparison.Ordinal))
                        .Single();

                    ctx.Authors.Remove(author1);

                    ctx.SaveChanges();

                    authorsNumber = ctx.Authors.Count();

                    var author2 = ctx.Authors
                        .Where(x => x.FullName.Equals("Author2", System.StringComparison.Ordinal))
                        .Single();

                    ctx.Entry(author2).State = EntityState.Deleted;

                    ctx.SaveChanges();

                    authorsNumber = ctx.Authors.Count();

                    var author3 = new Author { AuthorId = 3 };
                    ctx.Authors.Attach(author3);
                    ctx.Authors.Remove(author3);

                    ctx.SaveChanges();

                    authorsNumber = ctx.Authors.Count();

                    ctx.Database.ExecuteSqlCommand("DELETE FROM Authors WHERE AuthorId = '4'");

                    authorsNumber = ctx.Authors.Count();
                }
            }
        }

        private static void DemoOptimisticConcurrency()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString))
            {
                using (var ctx = new EFFeaturesContext(conn))
                {
                    ctx.Authors.AddRange(new[]
                    {
                        new Author { FullName = "Author1" }
                    });

                    ctx.SaveChanges();
                }

                EFFeaturesContext ctxForUser1 = new EFFeaturesContext(conn);
                EFFeaturesContext ctxForUser2 = new EFFeaturesContext(conn);

                try
                {
                    var authorForUser1 = ctxForUser1.Authors.Find(1);
                    var authorForUser2 = ctxForUser2.Authors.Find(1);

                    authorForUser2.FullName = "Author22";
                    ctxForUser2.SaveChanges();

                    authorForUser1.FullName = "Author11";
                    ctxForUser1.SaveChanges();
                }
                finally
                {
                    ctxForUser1.Dispose();
                    ctxForUser2.Dispose();
                }
            }
        }

        private static void DemoCommandInterceptor()
        {
            var log = CommandInterceptor.GetLog();
        }

        private static Hypermarket GetClosestHypermarket(DbGeography location)
        {
            using (var ctx = new EFFeatures5Context())
            {
                return ctx.Hypermarkets.OrderBy(x => x.Location.Distance(location)).FirstOrDefault();
            }
        }
    }
}
