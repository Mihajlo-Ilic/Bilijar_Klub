using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Get_Projekat.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Navedene sifre nisu iste!")]
        public string ConfirmPassword { get; set; }

        public string type { get; set; }

        public static List<SelectListItem> tipovi() {

            return new List<SelectListItem> {
            new SelectListItem {Text = "musterija"},
            new SelectListItem {Text = "radnik"}
            };
        
        }



    }
}
