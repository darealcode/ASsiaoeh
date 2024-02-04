using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace ASsiaoeh.ViewModels
{
    public class Register
    {
        [Required(ErrorMessage = "First Name required")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Last Name required")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Credit Card Number required")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Credit Card No must be a 16-digit number")]
        public string CreditCard { get; set; }

        [Required(ErrorMessage = "Mobile No required")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Mobile No must be a 8-digit number")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Billing Address required")]
        public string Billing { get; set; }

        [Required(ErrorMessage = "Shipping Address required")]
        [RegularExpression(@"^[a-zA-Z0-9\s.,#-]+$", ErrorMessage = "Shipping Address can contain letters, numbers, spaces, and special characters (.,#-)")]
        public string Shipping { get; set; }

        [Required(ErrorMessage = "Email address required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email address")]
        [EmailAddress(ErrorMessage = "Invalid Email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=!]).{12,}$", ErrorMessage = "Password must be strong (min 12 chars, lowercase, uppercase, number, special character)")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and confirmation password do not match")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new string[] { ".jpg" })]
        public IFormFile Photo { get; set; }
    }
}
