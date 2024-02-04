using ASsiaoeh.Model;
using ASsiaoeh.Services;
using ASsiaoeh.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;


namespace ASsiaoeh.Pages
{
	public class LoginModel : PageModel
	{
		[BindProperty]
		public Login LModel { get; set; }

		private readonly GoogleCaptchaService _captchaService;

		public LoginModel(GoogleCaptchaService captchaService, SignInManager<ApplicationUser> signInManager)
		{
			_captchaService = captchaService;
			this.signInManager = signInManager;
		}

		private readonly SignInManager<ApplicationUser> signInManager;

		public void OnGet()
		{
		}

		public async Task<IActionResult> OnPostAsync()
		{
			var errors = ModelState.Values.SelectMany(v => v.Errors);
			Console.WriteLine(errors);

            foreach (var error in errors)
            {
                foreach (var errorMessage in error.ErrorMessage)
                {
                    Console.WriteLine(errorMessage);
                }
            }
            if (ModelState.IsValid)
			{
				var captchaResult = await _captchaService.VerifyToken(LModel.Token);
				if (!captchaResult)
				{
					return Page();
				}

				var identityResult = await signInManager.PasswordSignInAsync(LModel.Email, LModel.Password,
					LModel.RememberMe, true);

				if (identityResult.Succeeded)
				{
					//Create the security context
					var claims = new List<Claim> {
					new Claim(ClaimTypes.Name, "c@c.com"),
					new Claim(ClaimTypes.Email, "c@c.com"),
					new Claim("Department", "HR")
				};
					var i = new ClaimsIdentity(claims, "MyCookieAuth");
					ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(i);
					await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
					// Generate a unique session token
					var sessionToken = Guid.NewGuid().ToString();

					// Store the session token in session
					HttpContext.Session.SetString("SessionToken", sessionToken);

					return RedirectToPage("Index");
				}
				else if (identityResult.IsLockedOut)
				{
					ModelState.AddModelError("", $"Account locked out. Please Try again Later");
				}
				else
				{
					ModelState.AddModelError("", "Username or Password incorrect");
				}
			}
			return Page();
		}
	}
}