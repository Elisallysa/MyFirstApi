using AutoMapper;
using MiPrimeritaAPI.BL.Contracts;
using MiPrimeritaAPI.CORE.DTO;
using MiPrimeritaAPI.DAL.Contracts;
using MiPrimeritaAPI.DAL.Tables;

namespace MiPrimeritaAPI.BL.Implementations
{
    public class LoginBL : ILoginBL
    {
        public ILoginDAL loginDAL { get; set; }
        public IMapper mapper { get; set; }

        public LoginBL(ILoginDAL loginDAL, IMapper mapper)
        {
            this.loginDAL = loginDAL;
            this.mapper = mapper;
        }

        /*
         * Sends a User DTO to the DAL to check if stored in DB.
         * Returns true if stored, false if not.
         */
        public bool Login(LoginDTO lo)
        {
            return loginDAL.Login(lo.Username, lo.Password) != null;
        }
        
    }
}
