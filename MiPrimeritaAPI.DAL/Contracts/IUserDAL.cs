
using MiPrimeritaAPI.DAL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimeritaAPI.DAL.Contracts
{
    public interface IUserDAL
    {
        public void Register(User u);
        public User? Login(string Username, string Password);
        public List<User> GetUsers();
        public User? GetUser(string Username, string Email);
        public User? findUser(string Username);
        public void Update(User user);
        public void Delete(string DNI);
    }
}
