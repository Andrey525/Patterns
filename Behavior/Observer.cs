namespace Patterns.Behavior.Observer
{
    interface IObserver
    {
        void Update();
    }

    class Driver : IObserver
    {
        public void Update()
        {
            Console.WriteLine("Damn! Car is broken!");
        }
    }

    interface IObservable
    {
        void RegisterObserver(IObserver observer);
        void UnregisterObserver(IObserver observer);
        void NotifyObservers();
    }

    class Car : IObservable
    {
        List<IObserver> _observers;

        public Car()
        {
            _observers = new List<IObserver>();
        }
        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void UnregisterObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Break()
        {
            NotifyObservers();
        }
    }
}
