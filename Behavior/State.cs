namespace Patterns.Behavior.State
{

    class Car
    {
        public State State { get; set; }
        public Car(State abstractState)
        {
            State = abstractState;
        }
        public void StartEngine()
        {
            State.StartEngine(this);
        }
        public void StopEngine()
        {
            State.StopEngine(this);
        }
    }
    abstract class State
    {
        public abstract void StartEngine(Car car);
        public abstract void StopEngine(Car car);
    }

    class StartedState : State
    {
        public override void StartEngine(Car car)
        {
            Console.WriteLine("The engine have already been started. Now your starter is burned out.");
            car.State = new BrokenState();
        }

        public override void StopEngine(Car car)
        {
            Console.WriteLine("Engine was stopped.");
            car.State = new StoppedState();
        }
    }

    class StoppedState : State
    {
        public override void StartEngine(Car car)
        {
            Console.WriteLine("Engine was started.");
            car.State = new StartedState();
        }

        public override void StopEngine(Car car)
        {
            Console.WriteLine("Stop stopped engine. Nothing to do.");
        }
    }

    class BrokenState : State
    {
        public override void StartEngine(Car car)
        {
            Console.WriteLine("Engine is broken. You can't start it.");
            car.State = new StartedState();
        }

        public override void StopEngine(Car car)
        {
            Console.WriteLine("Engine is stopped, because broken. Nothing to do.");
        }
    }
}
