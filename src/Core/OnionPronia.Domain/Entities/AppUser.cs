using Microsoft.AspNetCore.Identity;


namespace OnionPronia.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
       
    }
}
