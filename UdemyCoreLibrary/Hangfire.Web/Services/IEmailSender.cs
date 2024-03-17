using System.Threading.Tasks;

namespace Hangfire.Web.Services
{
    public interface IEmailSender
    {
        Task Sender(string userID, string message);
    }
}
