using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class UserRepo
    {
        SalonDbContext db;

        public UserRepo(SalonDbContext db)    // constructor injection
        {
            this.db = db;
        }

        public User? Login(string username, string password)  // Login under condition like get 
        {
            var user = (from u in db.Users
                        where u.Username.Equals(username) &&
                              u.Password.Equals(password)
                        select u).FirstOrDefault();

            return user;
        }

        public User Register(User user)    //Like Create 
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }

    }
}
