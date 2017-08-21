using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Services.Model
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public System.DateTime PublishDate { get; set; }
        public string ISBN { get; set; }

        public virtual AuthorModel Author { get; set; }
    }
}