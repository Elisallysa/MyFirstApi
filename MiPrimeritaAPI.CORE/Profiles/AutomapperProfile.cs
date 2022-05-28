using AutoMapper;
using MiPrimeritaAPI.CORE.DTO;
using MiPrimeritaAPI.DAL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimeritaAPI.CORE.Profiles
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<AlumnoDTO, Alumno>();
            CreateMap<Alumno, AlumnoDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<LoginDTO, UserDTO>();
            CreateMap<UserDTO, LoginDTO>();
        }

    }
}
