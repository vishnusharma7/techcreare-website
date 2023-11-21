using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using TechCreare.Models;
using TechCreare.Repository;

namespace EmailService
{
    public class EmailSender : IEmailSender
    {
        // https://ethereal.email/messages check email use this (Mail never deliver to you use id and password from appsetting to login)
        private readonly EmailConfiguration _emailConfig;
       

        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void SendEmail(Message message)

        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.From, _emailConfig.UserName));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content };

            var bodyBuilder = new BodyBuilder { HtmlBody = message.Content };
            if (message.Myfile != null)
            {
                byte[] fileBytes;
                using (var ms = new MemoryStream())
                {

                    {
                        message.Myfile.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }
                    bodyBuilder.Attachments.Add(message.Myfile.FileName, fileBytes, ContentType.Parse(message.Myfile.ContentType));
                    emailMessage.Body = bodyBuilder.ToMessageBody();
                    //return emailMessage;
                }
            }
            
            return emailMessage;  
            
        }
        private void Send(MimeMessage emailMessage)
        {
            using (var client = new SmtpClient())
            {
                try       
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, SecureSocketOptions.StartTls);
                    client.Timeout = 10000;
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                    client.Send(emailMessage);
                }
                catch (Exception ex)
                {
                    //log an error message or throw an exception or both.
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}

