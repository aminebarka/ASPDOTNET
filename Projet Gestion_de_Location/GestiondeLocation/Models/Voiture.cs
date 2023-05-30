using System.ComponentModel.DataAnnotations;

namespace GestiondeLocation.Models
{
    public class Voiture
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Matricule { get; set; }
        [Required]
        public string Marque { get; set; }
        [Required]
        public string Modele { get; set; }
        [Required]
        [Display(Name = "Image :")]
        public string Image { get; set; }

        internal static object FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }

}
