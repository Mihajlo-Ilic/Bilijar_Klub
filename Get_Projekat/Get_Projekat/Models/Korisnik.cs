using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Get_Projekat.Models
{
    public class Korisnik : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        public bool admin { get; set; }

    }
}
