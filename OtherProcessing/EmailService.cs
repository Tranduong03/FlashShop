namespace FlashShop.OtherProcessing;

using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

public class EmailService
{
	private readonly IConfiguration _configuration;

	public EmailService(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public async Task SendEmailAsync(string toEmail, string subject, string body)
	{
		var smtpConfig = _configuration.GetSection("Smtp");

		using (var client = new SmtpClient())
		{
			client.Host = smtpConfig["Host"];
			client.Port = int.Parse(smtpConfig["Port"]);
			client.EnableSsl = bool.Parse(smtpConfig["EnableSSL"]);
			client.Credentials = new NetworkCredential(smtpConfig["Username"], smtpConfig["Password"]);

			var mailMessage = new MailMessage
			{
				From = new MailAddress(smtpConfig["Username"]),
				Subject = subject,
				Body = body,
				IsBodyHtml = true
			};
			mailMessage.To.Add(toEmail);

			await client.SendMailAsync(mailMessage);
		}
	}
}
