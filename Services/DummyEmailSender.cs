using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace SuperEeveeDex.Services
{
    public class DummyEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            Console.WriteLine("=== DUMMY EMAIL SENDER ===");
            Console.WriteLine($"To: {email}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine("Message content:");
            Console.WriteLine(htmlMessage);  // This will include 2FA codes or confirmation links
            Console.WriteLine("==========================");
            return Task.CompletedTask;
        }
    }
}