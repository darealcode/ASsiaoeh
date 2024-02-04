using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace ASsiaoeh.ViewModels
{
    public class ResetPasswordModel : PageModel
    {
        [BindProperty]
        public string UserId { get; set; }

        [BindProperty]
        public string Code { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
            // Implement logic to verify the reset link
        }

        public IActionResult OnPost()
        {
            // Implement logic to reset the password
            // Use UserManager.ResetPasswordAsync
            return RedirectToPage("ResetPasswordConfirmation");
        }
    }
}
