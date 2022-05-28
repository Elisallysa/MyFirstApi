using MiPrimeritaAPI.DAL.Contracts;
using MiPrimeritaAPI.DAL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimeritaAPI.DAL.Implementations
{
    public class UserDAL : IUserDAL
    {
        public IESContext Context { get; set; }

        public UserDAL(IESContext Context)
        {
            this.Context=Context;
        }

        /**
         * Registers user in DB.
         */
        public void Register(User u)
        {
            Context.Users.Add(u);
            Context.SaveChanges();
        }

        /*
         * Gets User with specific Username and Password stored in DB.
         * Returns an User object.
         */
        public User? Login(string Username, string Password)
        {
            return Context.Users.FirstOrDefault(u => u.Username == Username && u.Password == Password);
        }

        public void Delete(string Username)
        {
            var user = findUser(Username);
            if (user != null)
                Context.Users.Remove(user);
            Context.SaveChanges();
        }

        public List<Alumno> GetAlumnos()
        {
            return Context.Alumnos.ToList();
        }

        

        public void Update(User user)
        {
            
            var userBD = findUser(user!.Username);
            if (userBD != null)
            {
                userBD.Username = user.Username;
            }
            Context.Users.Update(userBD);
            Context.SaveChanges();
        }

        void IUserDAL.Register(User u)
        {
            Context.Users.Add(u);
            Context.SaveChanges();
        }

        List<User> IUserDAL.GetUsers()
        {
            return Context.Users.ToList();
        }

        void IUserDAL.Update(User user)
        {
            var userBD = findUser(user!.Username);
            if (userBD != null)
            {
                userBD.Username = user.Username;
            }
            Context.Users.Update(userBD);
            Context.SaveChanges();
        }

        public User? GetUser(string Username, string Email)
        {
            throw new NotImplementedException();
        }

        public User? findUser(string Username)
        {
            return Context.Users.FirstOrDefault(u => u.Username == Username);
        }
    }
}
