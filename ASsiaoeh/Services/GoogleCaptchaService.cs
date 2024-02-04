using ASsiaoeh.Model;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ASsiaoeh.Services
{
	public class GoogleCaptchaService
	{
	
	
		public async Task<bool> VerifyToken(string token)
		{
			try
			{
				var url = "https://www.google.com/recaptcha/api/siteverify";
				var parameters = new Dictionary<string, string>
				{
					{ "secret","6LfLhGUpAAAAAP9wetwrPLaBF5cJYse4njN5eg_J" },
					{ "response", token }
				};

				

				using (var client = new HttpClient())
				{
					var response = await client.PostAsync(url, new FormUrlEncodedContent(parameters));

					if (response.StatusCode != HttpStatusCode.OK)
					{
						return false;
					}

					var responseString = await response.Content.ReadAsStringAsync();
					var googleResult = JsonConvert.DeserializeObject<GoogleCaptchaResponse>(responseString);
					if (googleResult.success & googleResult.score >= 0.5)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			catch (Exception e)
			{

				return false;
			}
		}
	}
}