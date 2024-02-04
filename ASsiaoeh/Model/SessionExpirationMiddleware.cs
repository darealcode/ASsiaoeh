
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ASsiaoeh.ViewModels;


namespace ASsiaoeh.Model
{


    public class SessionExpirationMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionExpirationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Ensure that the session middleware has been configured
            if (context.Session != null)
            {
                if (context.Session.TryGetValue("SessionToken", out var sessionToken))
                {
                    // Do something with the sessionToken if needed

                    // Check for session expiration here
                    var sessionTimeout = TimeSpan.FromMinutes(1); // Set Sessoin to 1 minutes
                    var lastActivityTime = context.Session.Get<DateTime>("LastActivityTime");

                    if (DateTime.Now - lastActivityTime > sessionTimeout)
                    {
                        // Session has expired, handle accordingly
                        context.Session.Remove("SessionToken");
                        // You may want to perform additional actions here, e.g., sign out the user
                    }
                }
            }

            await _next(context);
        }
    }
}
