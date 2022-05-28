using MiPrimeritaAPI.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimeritaAPI.BL.Contracts
{
    public interface IUserBL
    {
        public bool Register(UserDTO u);
        public UserDTO? Login(LoginDTO lo);
        public List<UserDTO> GetUsers();
        public UserDTO? GetUser(string Nombre);
        public void Update(UserDTO user);
        public void Delete(string Nombre);
    }
}
