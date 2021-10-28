using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Get_Projekat.Models
{
    public class Termin
    {

        [Required]
        public int TerminId { get; set; }

        [Required]
        [ForeignKey("StoId")]
        public int StoId { get; set; }
        public Sto Sto { get; set; }

        [Required]
        [ForeignKey("Id")]
        public string UserId { get; set; }
        public Korisnik Korisnik { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }

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
