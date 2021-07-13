using StoreDapper.Domain.StoreContext.Services;

namespace StoreDapper.Tests.Fakes
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
            
        }
    }
}