
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASsiaoeh.Pages
{
	public class PrivacyModel : PageModel
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public PrivacyModel(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public IActionResult OnGet()
		{
			// Check if the session contains the user ID
			if (_httpContextAccessor.HttpContext.Session.GetString("UserId") == null)
			{
				// Session expired, redirect to the login page
				return RedirectToPage("/Login");
			}

			// Session is active, continue with normal page logic
			return Page();
		}
	}
}
