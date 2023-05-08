using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crop_Deal_WebApi.Controllers.Models
{
    public class Crop
    {
        [Key]
        [Required]
        public int Crop_id { get; set; }

        [Required(ErrorMessage ="Please enter the crop name")]
        [Display(Name ="CropName")]
        public string? Crop_name { get; set; }

        [Required]
        public string? Crop_image { get; set; }

        [ForeignKey("User")]
        public int id { get; set; }
        public User? User { get; set; }

        [ForeignKey("Crop_Details")]
        public int CropDetails_id { get; set; }
        public Crop_Details? Crop_Details { get; set; }

    }
}
