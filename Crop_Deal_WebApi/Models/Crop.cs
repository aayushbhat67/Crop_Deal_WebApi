using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public int User_id { get; set; }
        [JsonIgnore]
        public User? User { get; set; }

        [ForeignKey("CropDetail")]
        [JsonIgnore]
        public int CropDetails_id { get; set; }
        [JsonIgnore]
        public CropDetail? CropDetail { get; set; }

    }
}
