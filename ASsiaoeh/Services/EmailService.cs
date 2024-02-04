using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Threading.Tasks;

namespace ASsiaoeh.Services // Make sure this namespace matches your project's namespace
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress("Your Name", "your-email@example.com")); // Change "Your Name" and "your-email@example.com"
                emailMessage.To.Add(new MailboxAddress("", email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart("plain")
                {
                    Text = message
                };

                using var client = new SmtpClient();
                await client.ConnectAsync("smtp.gmail.com", 465, SecureSocketOptions.StartTls); // Change SMTP server details
                await client.AuthenticateAsync("killingitman321@gmail.com", "fjqz zeqv gbyf brka"); // Change your email and password
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }

    }
}