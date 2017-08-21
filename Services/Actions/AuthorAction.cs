using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using System.Data.Entity;
using Services.Model;

namespace Services.Actions
{
    public class AuthorAction
    {
        TaskDbEntities db = new TaskDbEntities();
        List<Author> authors = new List<Author>();
        private List<AuthorModel> modellist = new List<AuthorModel>();
        private AuthorModel TempAuth;

        public IEnumerable<AuthorModel> GetAllAuthors()
        {



            authors = db.Authors.ToList();



            foreach (Author t in authors)
            {
                TempAuth = new AuthorModel();
                TempAuth.Id = t.Id;
                TempAuth.Name = t.Name;
                TempAuth.PhoneNumber = t.PhoneNumber;
                TempAuth.EmailAddress = t.EmailAddress;
                modellist.Add(this.TempAuth);

            }
            return modellist;

        }
        private Data.Author Auth;
        public AuthorModel GetByName(string id)
        {
            Auth = db.Authors.FirstOrDefault(x => x.Name == id);

            TempAuth = new Model.AuthorModel();
            TempAuth.Id = Auth.Id;
            TempAuth.Name = Auth.Name;
            TempAuth.PhoneNumber = Auth.PhoneNumber;
            TempAuth.EmailAddress = Auth.EmailAddress;

            return TempAuth;



        }
        public void AddAuthor(AuthorModel UserAuthor)
        {
            Author DataAuthor = new Author();
            DataAuthor.Id = UserAuthor.Id;
            DataAuthor.Name = UserAuthor.Name;
            DataAuthor.EmailAddress = UserAuthor.EmailAddress;
            DataAuthor.PhoneNumber = UserAuthor.PhoneNumber;
            db.Authors.Add(DataAuthor);
            db.SaveChanges();

        }
        public void EditAuthor(int _AuthId, AuthorModel UserAuthor)
        {
            Auth = db.Authors.FirstOrDefault(x => x.Id == _AuthId);

            db.Authors.Remove(Auth);
            db.SaveChanges();
            Author LocalAuth = new Author();
            LocalAuth.Id = UserAuthor.Id;
            LocalAuth.Name = UserAuthor.Name;
            LocalAuth.PhoneNumber = UserAuthor.PhoneNumber;
            LocalAuth.EmailAddress = UserAuthor.EmailAddress;
            db.Authors.Add(LocalAuth);
            db.SaveChanges();

        }
        public void DeleteAuthor(int _id)
        {
            Auth = db.Authors.FirstOrDefault(x => x.Id == _id);

            db.Authors.Remove(Auth);
            db.SaveChanges();
        }
    }


}


