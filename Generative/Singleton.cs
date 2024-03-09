namespace Patterns.Generative.Singleton
{
    internal class Petrol
    {
        private static Petrol? _instance;

        public string Name { get; private set; }

        public void Print()
        {
            Console.WriteLine($"This is {Name}");
        }

        private Petrol(string name)
        {
            Name = name;
        }

        public static Petrol GetInstance(string name)
        {
            if (_instance == null)
            {
                _instance = new Petrol(name);
            }
            return _instance;
        }
    }
}
