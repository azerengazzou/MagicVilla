namespace MagicVilla_Api.Logging
{
    public class LoggingV2 : ILogging
    {
        public void Log(string message, string type)
        {
            if (type == "error")
            {
                Console.WriteLine("Error - " + message);
                Console.BackgroundColor = ConsoleColor.Black;

            }
            else
            {
                Console.WriteLine(message);
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
        }
    }
}
