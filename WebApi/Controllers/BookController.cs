using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Services.Actions;
using Services.Model;

namespace WebApi.Controllers
{
    public class BookController : ApiController
    {
        private BookAction bookActions;
        public IEnumerable<BookModel> Get()
        {
            bookActions = new BookAction();
            return bookActions.GetAllBooks();

        }

        public BookModel Get(string id)
        {
            bookActions = new BookAction();
            return bookActions.GetByBook(id);
        }
    }
}
