namespace WebApiDemo.Services
{
    public class SingeltonService
    {
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
