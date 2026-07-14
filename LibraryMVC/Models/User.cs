using Microsoft.AspNetCore.Identity;

namespace LibraryMVC.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
