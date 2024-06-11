using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RazorPageDemo.Data
{
    public class AppUser:IdentityUser
    {
        [Required]
        [MaxLength(10)]
        [Unicode(false)]
        [Display(Name ="Id code")]
        public string IdCode { get; set; }
        [Display(Name ="Full Name")]
        public string Description { get; set; } = default!;

        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }
    }
}
