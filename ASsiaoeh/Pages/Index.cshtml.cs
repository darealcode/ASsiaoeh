using ASsiaoeh.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace ASsiaoeh.Pages
{
    [Authorize]
    public class IndexModel : MyBasePageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public string SessionKeyTime { get; private set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ILogger<IndexModel> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = _userManager.GetUserAsync(User).Result;
                // Decrypt
                var dataProtectionProvider = DataProtectionProvider.Create("EncryptData");
                var protector = dataProtectionProvider.CreateProtector("MySecretKey");
                var decryptedCreditCardNo = protector.Unprotect(user.CreditCard);
                if (user != null)
                {
                    ViewData["FName"] = user.FName;
                    ViewData["LName"] = user.LName;
                    ViewData["CreditCard"] = decryptedCreditCardNo;
                    ViewData["Mobile"] = user.Mobile;
                    ViewData["Billing"] = user.Billing;
                    ViewData["Shipping"] = user.Shipping;
                    ViewData["Email"] = user.Email;
                    ViewData["Photo"] = user.Photo;
                }

            }
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            HttpContext.Session.Remove("SessionToken");

            await _signInManager.SignOutAsync();
            return RedirectToPage("Login");
        }

    }
}