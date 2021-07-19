using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFFeatures.Models.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FullName { get; set; }
        //[Timestamp]
        //public byte[] Timestamp { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
