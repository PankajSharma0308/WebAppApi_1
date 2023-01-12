namespace WebAppApi_1.Logging
{
    public class Logging : ILogging
    {
        public void Log(string message, string type)
        {
            var err_msg = (type == "error") ? ("ERROR - " + message) : message;
            Console.WriteLine(err_msg);

        }
    }
}
