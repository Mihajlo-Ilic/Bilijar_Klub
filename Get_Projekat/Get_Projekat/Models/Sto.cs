using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Get_Projekat.Models
{
    public class Sto
    {
        
        [Required,Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StoId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Description { get; set; }
        public float cena { get; set; }
    }
}
