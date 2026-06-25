using Microsoft.AspNetCore.Identity;

namespace MuhsinYigitOrucu.EntityLayer.Entities
{
    public class AppUser : IdentityUser
    {
        public string? NameSurname { get; set; }
    }
}
