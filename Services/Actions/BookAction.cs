using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using Data;
using Services.Model;
using Services.Actions;

namespace Services.Actions
{
    public class BookAction
    {
        TaskDbEntities db;
        List<Data.Book> booklist = new List<Data.Book>();
        List<BookModel> Localbooks = new List<BookModel>();
        private BookModel OneBook;

        public IEnumerable<BookModel> GetAllBooks()
        {
            db = new TaskDbEntities();
            booklist = db.Books.ToList();

            foreach (var t in booklist)
            {
                OneBook = new BookModel();
                OneBook.Id = t.Id;
                OneBook.Name = t.Name;
                OneBook.AuthorId = t.AuthorId;
                OneBook.ISBN = t.ISBN;
                OneBook.PublishDate = t.PublishDate;

                Localbooks.Add(this.OneBook);

            }
            return Localbooks;


        }
        private Data.Book priauth;
        private Author priauth1;

        public BookModel GetByBook(string id)
        {
            db = new TaskDbEntities();
            priauth1 = db.Authors.ToList().FirstOrDefault(x => x.Name == id);


            priauth = db.Books.ToList().FirstOrDefault(x => x.AuthorId == priauth1.Id);

            OneBook = new BookModel();
            OneBook.Id = priauth.Id;
            OneBook.Name = priauth.Name;
            OneBook.AuthorId = priauth.AuthorId;
            OneBook.PublishDate = priauth.PublishDate;
            OneBook.ISBN = priauth.ISBN;
            return OneBook;
        }
    }
}