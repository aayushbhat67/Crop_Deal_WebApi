using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Text.Json.Serialization;

namespace Crop_Deal_WebApi.Models
{
    public class Bank
    {
        [Key]
        [Required]
        public int BankDetail_id { get; set; }

        [Required(ErrorMessage = "Please enter the bank name")]
        [Display(Name = "BankName")]
        public string? Bank_Name { get; set; }


        [Required(ErrorMessage = "Please enter the Bank account number")]
        [RegularExpression(@"^([0-9]{9,18})$", ErrorMessage = "Invalid Bank Account Number")]
        [Display(Name = "AccountNumber")]
        public int? AccountNumber { get; set; }


        [Required(ErrorMessage = "Please enter the ifsc code")]
        [RegularExpression(@"^([A-Z|a-z]{4}[0][a-zA-Z0-9]{6})$", ErrorMessage = "Invalid IFSC code")]
        [Display(Name = "IFSC")]

        public string? IFSC_Code { get; set; }

        [ForeignKey("User")]
        [JsonIgnore]
        public int User_id { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}
