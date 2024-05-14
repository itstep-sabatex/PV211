
namespace WebApiDemo.Services
{
    public class UTCTimeService : ITimeService
    {
        public DateTime GetDateTime()
        {
            return DateTime.UtcNow;
        }
    }
}
