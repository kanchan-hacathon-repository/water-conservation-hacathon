using System;
using WaterConservation.Entities;

namespace WaterConservation.BusinessLogic
{
    public class GreetingsManager
    {
        public GreetingsManager()
        {
        }

        public Greetings GetGreetingMessage(string dateTime)
        {
            Greetings greetings = new Greetings();
            DateTime timeOfDayGreeting = DateTime.Now;
            if (!string.IsNullOrEmpty(dateTime))
            {
                DateTime.TryParse(dateTime, out timeOfDayGreeting);
            }
            if (timeOfDayGreeting.Hour >= 5 && timeOfDayGreeting.Hour < 12)
            {
                greetings.GreetingMessage = "Good morning!";
            }
            else if (timeOfDayGreeting.Hour >= 12 && timeOfDayGreeting.Hour < 16)
            {
                greetings.GreetingMessage = "Good afternoon!";
            }
            else if (timeOfDayGreeting.Hour >= 16 && timeOfDayGreeting.Hour < 20)
            {
                greetings.GreetingMessage = "Good evening!";
            }
            else
            {
                greetings.GreetingMessage = "Good night!";
            }

            return greetings;
        }
    }
}
