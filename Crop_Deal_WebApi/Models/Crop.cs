using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Crop_Deal_WebApi.Models
{
    public class Crop
    {
        [Key]
        [Required]
        public int Crop_id { get; set; }

        [Required(ErrorMessage = "Please enter the crop name")]
        [Display(Name = "CropName")]
        public string? Crop_name { get; set; }

        [Required]
        public string? Crop_image { get; set; }

        [ForeignKey("User")]
        public int User_id { get; set; }
        public User? User { get; set; }

        [ForeignKey("CropDetail")]
        public int CropDetails_id { get; set; }
        public CropDetail? CropDetail { get; set; }

    }
}
