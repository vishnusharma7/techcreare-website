using MimeKit;

namespace TechCreare.Models
{
    public class Message
    {
        

        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
       
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        
        public IFormFile Myfile { get; }

       
       
        public string From { get; set; }
        public Message(IEnumerable<string> to, string subject, string content,IFormFile myfile)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => MailboxAddress.Parse(x)));
            Subject = subject;
            Content = content;

            //this.attachments = attachments;
            this.Myfile = myfile;
        }
       



    }
}
