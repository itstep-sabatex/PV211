
namespace WebApiDemo.Services
{
    public class CurrentTimeService : ITimeService
    {
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
