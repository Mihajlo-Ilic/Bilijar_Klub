using System.ComponentModel.DataAnnotations;

namespace Get_Projekat.Models.ViewModels
{
    public class AdminNovTermin
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public int StoId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string Start { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string End { get; set; }

    }
}
