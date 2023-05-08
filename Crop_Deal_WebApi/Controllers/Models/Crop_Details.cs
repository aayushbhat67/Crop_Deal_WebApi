using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crop_Deal_WebApi.Controllers.Models
{
    public class Crop_Details
    {
        [Key]
        [Required]
        public int CropDetails_id { get; set; }
        

        
        [Required]
        public string? Crop_name { get; set; }
        [Required]
        public string? CropDetail_description { get; set; }
        [Required]
        public int? Crop_type { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public int? Price { get; set; }
        [Required]
        public string? Location { get; set; }

        
    }
}
