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
    public class AuthorController : ApiController
    {
        private AuthorAction authActions;

        public IEnumerable<Services.Model.AuthorModel> Get()
        {
            authActions = new AuthorAction();
            return authActions.GetAllAuthors();
        }

        public AuthorModel Get(string id)
        {
            authActions = new AuthorAction();
            return authActions.GetByName(id);
        }
        public void Post([FromBody] AuthorModel val)
        {
            authActions = new AuthorAction();
            authActions.AddAuthor(val);
        }
        public void Put(int id, [FromBody] AuthorModel LcAu)
        {

            authActions = new AuthorAction();
            authActions.EditAuthor(id, LcAu);

        }
        public void Delete(int id)
        {
            authActions = new AuthorAction();
            authActions.DeleteAuthor(id);
        }
    }
    

}
