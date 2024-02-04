using ASsiaoeh.Model;
using ASsiaoeh.ViewModels;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASsiaoeh.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        [BindProperty]
        public Register registerModel { get; set; }

        public RegisterModel(UserManager<ApplicationUser> userManager,
                             SignInManager<ApplicationUser> signInManager,
                             RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {

                // Check for unique email before attempting user creation
                var existingUser = await userManager.FindByEmailAsync(registerModel.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("registerModel.Email", "Email address is already in use.");
                    return Page();
                }

                var dataProtectionProvider = DataProtectionProvider.Create("EncryptData");
                var protector = dataProtectionProvider.CreateProtector("MySecretKey");

                var user = new ApplicationUser()
                {
                    UserName = registerModel.Email,
                    FName = registerModel.FName,
                    LName = registerModel.LName,
                    CreditCard = protector.Protect(registerModel.CreditCard),
                    Mobile = registerModel.Mobile,
                    Billing = registerModel.Billing,
                    Shipping = registerModel.Shipping,
                    Email = registerModel.Email,
                    Photo = await ConvertFormFileToByteArray(registerModel.Photo)

                };

                // Create the Admin role if NOT exist
                IdentityRole role = await roleManager.FindByIdAsync("Admin");
                if (role == null)
                {
                    IdentityResult result2 = await roleManager.CreateAsync(new IdentityRole("Admin"));
                    if (!result2.Succeeded)
                    {
                        ModelState.AddModelError("", "Create role admin failed");
                    }
                }

                var result = await userManager.CreateAsync(user, registerModel.Password);
                if (result.Succeeded)
                {
                    // Add the user to the Admin role
                    result = await userManager.AddToRoleAsync(user, "Admin");

                    await signInManager.SignInAsync(user, false);
                    return RedirectToPage("Index");
                }

                // Handle user creation errors
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            // ModelState is not valid, return to the registration page with validation errors
            return Page();
        }

        private async Task<byte[]> ConvertFormFileToByteArray(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
