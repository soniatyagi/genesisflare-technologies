using GFT.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;

namespace GFT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly IToastNotification _notyf;

		public HomeController(ILogger<HomeController> logger, IToastNotification notyf)
		{
			_logger = logger;
			_notyf = notyf;
		}

		public IActionResult Index()
        {
			ViewBag.Navbar = "Home";
			return View();
        }

		[HttpPost]
		public IActionResult Index(ContactUs user)
		{
			ViewBag.Navbar = "Home";
			try
			{
				// Send the OTP via Email
				using (MailMessage mm = new MailMessage("s20293507@gmail.com", "sonia.tyagi.0609@gmail.com"))
				{
					string senderEmail = "s20293507@gmail.com";
					string senderPassword = "ybjtcvlwnboehvnk";

					SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
					smtpClient.EnableSsl = true;
					smtpClient.UseDefaultCredentials = false;
					smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

					// Set the properties of the email message.
					mm.Subject = user.Name;
					mm.Body = $"Name: {user.Name}\nEmail: {user.Email}\nMobile: {user.Phone}\nMessage: {user.Message}";
					mm.IsBodyHtml = false; // You can set this to true if your message body is HTML.

					// Send the email.
					smtpClient.Send(mm);
				}
				_notyf.AddSuccessToastMessage("Message noted. We will get back to you soon.");
				user.Name = string.Empty;
				user.Email = string.Empty;
				user.Phone = string.Empty;
				user.Message = string.Empty;

				return View();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return View();
		}

		public IActionResult About()
		{
			ViewBag.Navbar = "About";
			return View();
		}

		public IActionResult Blog()
		{
			ViewBag.Navbar = "Blog";
			return View();
		}

		public IActionResult BlogDetail()
		{
			ViewBag.Navbar = "Blog";
			return View();
		}

		public IActionResult Contact()
		{
			ViewBag.Navbar = "Contact";
			return View();
		}

		[HttpPost]
		public IActionResult Contact(ContactUs user)
		{
			ViewBag.Navbar = "Contact"; ;
			try
			{
				// Send the OTP via Email
				using (MailMessage mm = new MailMessage("s20293507@gmail.com", "sonia.tyagi.0609@gmail.com"))
				{
					string senderEmail = "s20293507@gmail.com";
					string senderPassword = "ybjtcvlwnboehvnk";

					SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
					smtpClient.EnableSsl = true;
					smtpClient.UseDefaultCredentials = false;
					smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

					// Set the properties of the email message.
					mm.Subject = user.Name;
					mm.Body = $"Name: {user.Name}\nEmail: {user.Email}\nMobile: {user.Phone}\nMessage: {user.Message}";
					mm.IsBodyHtml = false; // You can set this to true if your message body is HTML.

					// Send the email.
					smtpClient.Send(mm);
				}
				_notyf.AddSuccessToastMessage("Message noted. We will get back to you soon.");
				user.Name = string.Empty;
				user.Email = string.Empty;
				user.Phone = string.Empty;
				user.Message = string.Empty;

				return View("Contact", user);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return View("Contact");
		}

		public IActionResult NotFound()
		{
			return View();
		}

		public IActionResult Project()
		{
			ViewBag.Navbar = "Project";
			return View();
		}

		public IActionResult ProjectDetail()
		{
			ViewBag.Navbar = "Project";
			return View();
		}

		public IActionResult ServiceDetail()
		{
			ViewBag.Navbar = "Service";
			return View();
		}

		public IActionResult Services()
		{
			ViewBag.Navbar = "Service";
			return View();
		}
		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}