using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Crop_Deal_WebApi.Models
{
    public class User
    {
        [Key]
        public int User_id { get; set; }

        [Required(ErrorMessage = "Please enter the username")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Username")]
        public string? Username { get; set; }


        [Required(ErrorMessage = "Please enter the email")]
        [Display(Name = "EmailId")]


        public string? Email { get; set; }


        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }



       // [Required]
       // public byte[]? PasswordHash { get; set; }



       // [Required]
       // public byte[]? PasswordSalt { get; set; }


        [Required(ErrorMessage = "Please enter the contact number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Number")]
        [Display(Name = "Contact Number")]
        public string? Contact { get; set; }

        [Required(ErrorMessage = "Please enter the address")]
        [Display(Name = "Address")]

        public string? Address { get; set; }


        [Required(ErrorMessage = "Please enter your DOB")]
        [DataType(DataType.Date)]
        [Display(Name = "DateofBirth")]
        public DateTime DBO { get; set; }

        [Required]
        public string Roles { get; set; } = string.Empty;



        public bool Is_subscribe { get; set; } = false;

        public bool Is_Active { get; set; } = false;

    }
}
