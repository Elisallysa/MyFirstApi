namespace MiPrimeritaAPI.CORE.DTO
{
    public class UserDTO

    {      
        public string? Username { get; set; }
        public string? Mail { get; set; }
        public string? Password { get; set; }
        public DateOnly Birthday { get; set; }
    }
}
