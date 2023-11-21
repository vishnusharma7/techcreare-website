using TechCreare.Models;

namespace TechCreare.Repository
{
    public interface IEmailSender
    {
        void SaveChanges();
        void SendEmail(Message message);
        
    }
}
