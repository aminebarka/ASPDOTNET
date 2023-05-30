using System.ComponentModel.DataAnnotations;

namespace GestiondeLocation.Models
{
    public class Location
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime Duree  { get; set; }
        [Required]
        public float Prix { get; set; }
     
     

    }

}
