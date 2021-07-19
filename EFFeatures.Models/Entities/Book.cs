using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFFeatures.Models.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        [StringLength(350)]
        public string Title { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}
