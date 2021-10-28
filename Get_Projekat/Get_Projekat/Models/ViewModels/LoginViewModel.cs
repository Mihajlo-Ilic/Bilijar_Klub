using System.ComponentModel.DataAnnotations;

namespace Get_Projekat.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Zapamti me?")]
        public bool rememberMe {  get; set; } = false;

    }
}
