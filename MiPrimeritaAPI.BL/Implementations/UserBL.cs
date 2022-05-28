using AutoMapper;
using MiPrimeritaAPI.BL.Contracts;
using MiPrimeritaAPI.CORE.DTO;
using MiPrimeritaAPI.DAL.Contracts;
using MiPrimeritaAPI.DAL.Tables;

namespace MiPrimeritaAPI.BL.Implementations
{
    public class UserBL : IUserBL
    {
        public IUserDAL userDAL { get; set; }
        public IMapper mapper { get; set; }

        public UserBL(IUserDAL userDAL, IMapper mapper)
        {
            this.userDAL = userDAL;
            this.mapper = mapper;
        }

        /*
         * Sends a User DTO to the DAL to be registered.
         * Returns true if registered, false if not.
         */
        public bool Register(UserDTO u)
        {
            var user = userDAL.GetUser(u.Username, u.Mail);
            if (user == null)
            {
                user = mapper.Map<User>(u);

                userDAL.Register(user);
                //Enviar email
                return true;
            }
            return false;
        }


        /*
         * Sends a User DTO to the DAL to check if stored in DB.
         * Returns true if stored, false if not.
         */
        public UserDTO? Login(LoginDTO lo)
        {
            var user = userDAL.Login(lo.Username, lo.Password);
            return mapper.Map<UserDTO>(user);
        }

        public List<UserDTO> GetUsers()
        {
            var users = userDAL.GetUsers();
            var userDTOs = mapper.Map<List<UserDTO>>(users);
            return userDTOs;
        }

        public UserDTO? GetUser(string Nombre)
        {
            var user = userDAL.findUser(Nombre);
            if (user != null)
            {
                var userDTO = mapper.Map<UserDTO>(user);
                return userDTO;
            }
            else
            {
                return null;
            }
        }

        public void Update(UserDTO userDTO)
        {
            var user = mapper.Map<User>(userDTO);

            userDAL.Update(user);
        }

        public void Delete(string Username)
        {
            userDAL.Delete(Username);
        }

    }
}
