using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crop_Deal_WebApi.Controllers.Models
{
    public class Invoice_Details
    {
        [Key]
        public int Invoice_id { get; set; }

       
        

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Payment_Mode { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = string.Empty;

        [Required]
        public DateTime Date_created { get; set; }


        [ForeignKey("User")]
        public int id { get; set; }
        public User? User { get; set; }


        [ForeignKey("Crop_Details")]
        public int CropDetails_id { get; set; }
        public Crop_Details? Crop_Details { get; set; }

    }
}
