using System.ComponentModel.DataAnnotations;

namespace GestiondeLocation.ViewModels
{
    public class CreateViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Matricule { get; set; }
        [Required]

        public string Marque { get; set; }
        [Required]

        public string Modele{ get; set; }
        [Required]
        [Display(Name = "Image :")]
        public IFormFile ImagePath { get; set; }
    }
}
