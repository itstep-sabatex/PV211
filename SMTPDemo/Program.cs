// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Mail;

Console.WriteLine("Hello, World!");
var mailServer = "smtp.gmail.com";
var pass = "password";
var login = "fake@gmail.com";


var smtpClient = new SmtpClient()
{
    Host = mailServer,
    Port = 587, //25
    EnableSsl = true,
    Credentials = new NetworkCredential(login, pass)
};
using (var mail = new MailMessage(login,"destination@gmail.com","Hello world","This letter is tested."))
{
    mail.IsBodyHtml = true;
    await smtpClient.SendMailAsync(mail);
}