namespace OdeToFood
{
    public interface IGreeting
    {
        string GetMessageOfTheDay();
    }

    public class GreetingService : IGreeting
    {
        public string GetMessageOfTheDay()
        {
            return "Greetings!!!";
        }
    }
}