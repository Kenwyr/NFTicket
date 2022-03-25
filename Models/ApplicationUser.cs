using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace NFT_API.Models
{
    public class ApplicationUser:IdentityUser
    {
        public int Id { get; set; }

        [Display(Name = "Full name")]
        public string FullName { get; set; }
    }
}
