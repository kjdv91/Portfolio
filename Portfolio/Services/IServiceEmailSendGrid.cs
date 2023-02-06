using Portfolio.Models;

namespace Portfolio.Services
{
    public interface IServiceEmailSendGrid
    {
        Task Send(ContactViewModel contact);
    }
}
