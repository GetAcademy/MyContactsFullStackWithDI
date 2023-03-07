namespace MyContactsFullStack
{
    public class ExampleSingleton
    {
        private ExampleSingleton()
        {

        }

        private static ExampleSingleton? _instance;
        public static ExampleSingleton Instance => _instance ??= new ExampleSingleton();

        //private static ExampleSingleton _instance;
        //public static ExampleSingleton Instance
        //{
        //    get
        //    {
        //        if (_instance == null) _instance = new ExampleSingleton();
        //        return _instance;
        //    }
        //}
    }
}
