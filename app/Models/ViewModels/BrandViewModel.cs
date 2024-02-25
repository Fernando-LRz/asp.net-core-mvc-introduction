using System.ComponentModel.DataAnnotations;

namespace app.Models.ViewModels
{
    public class BrandViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
    }
}