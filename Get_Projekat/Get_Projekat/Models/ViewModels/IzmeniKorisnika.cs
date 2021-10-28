using System.ComponentModel.DataAnnotations;

namespace Get_Projekat.Models.ViewModels
{
    public class IzmeniKorisnika
    {
        [Required]
        [DataType(DataType.Text)]
        public string Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [MinLength(0)]
        public string Password { get; set; }
    }
}
