using Microsoft.AspNetCore.Identity;
using Staj.Core.Models;

namespace Staj.Repository.Models
{
    public class AppUser:IdentityUser
    {
        public string? City { get; set; }
        public string? Picture { get; set; }
        public DateTime? BirthDay { get; set; }
        public Gender? Gender { get; set; }

        public ICollection<Content> contents { get; set; }
    }
}
