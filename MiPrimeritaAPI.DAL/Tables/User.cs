using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimeritaAPI.DAL.Tables
{
    public class User
    {
        [Key]
        public int Id { get; set; } 
        public string? Username { get; set; }
        public string? Mail { get; set; }
        public string Password { get; set; }
    }
}
