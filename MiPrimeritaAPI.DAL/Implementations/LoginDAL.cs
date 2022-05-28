using MiPrimeritaAPI.DAL.Contracts;
using MiPrimeritaAPI.DAL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimeritaAPI.DAL.Implementations
{
    public class LoginDAL : ILoginDAL
    {
        public IESContext Context { get; set; }

        public LoginDAL(IESContext Context)
        {
            this.Context=Context;
        }

        /*
         * Gets User with specific Username and Password stored in DB.
         * Returns an User object.
         */
        public User? Login(string Email, string Password)
        {
            if (GetUser(Email,Password) != null)
            {
                return Context.Users.FirstOrDefault(u => u.Mail == Email && u.Password == Password);
            }
            return null;
        }

        public void Register(User u)
        {
            Context.Users.Add(u);
            Context.SaveChanges();
        }

        public User? GetUser(string Username, string Email)
        {
            return Context.Users.FirstOrDefault(u => u.Username == Username || u.Mail == Email);
        }
    }
}
