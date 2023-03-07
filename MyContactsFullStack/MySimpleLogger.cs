namespace MyContactsFullStack
{
    public class MySimpleLogger : ISimpleLogger
    {
        public MySimpleLogger(ISomethingElse somethingElse)
        {
            
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
