namespace WebApiDemo.Services
{
    public class SCopedService
    {
        private readonly SingeltonService _singeltonService;
        public SCopedService(SingeltonService singeltonService)
        {
            _singeltonService = singeltonService;
        }

        int counter = 0;
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }
        public int Increment()
        {
            counter++;
            return counter;

        }
    }
}
