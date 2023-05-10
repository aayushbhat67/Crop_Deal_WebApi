using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Crop_Deal_WebApi.Models
{
    public class InvoiceDetail
    {
        [Key]
        [Required]

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
        public int User_id{ get; set; }
        public User? User { get; set; }


        [ForeignKey("CropDetail")]
        public int CropDetails_id { get; set; }
        public CropDetail? CropDetail { get; set; }

    }
}
