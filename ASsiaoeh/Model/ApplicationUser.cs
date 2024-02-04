using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ASsiaoeh.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string CreditCard { get; set; }
        public string Mobile { get; set; }
        public string Billing { get; set; }
        public string Shipping { get; set; }
        public string Email { get; set; }
        public byte[] Photo { get; set; }

    }
}
