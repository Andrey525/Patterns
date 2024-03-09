namespace Patterns.Behavior.Strategy
{
    interface IRoutable
    {
        void BuildRoute();
    }

    class FootRoute : IRoutable
    {
        public void BuildRoute()
        {
            Console.WriteLine("Build foot route");
        }
    }

    class CarRoute : IRoutable
    {
        public void BuildRoute()
        {
            Console.WriteLine("Build car route");
        }
    }

    class Navigator
    {
        public IRoutable Routable { get; set; }

        public Navigator(IRoutable routable)
        {
            Routable = routable;
        }

        public void BuildRoute()
        {
            Routable.BuildRoute();
        }
    }
}
