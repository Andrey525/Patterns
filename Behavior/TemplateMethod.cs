namespace Patterns.Behavior.TemplateMethod
{
    abstract class Worker
    {
        public void TemplateMethod()
        {
            GoToTheWork();
            Work();
            HaveDinner();
            GoHome();
        }

        public abstract void GoToTheWork();
        public abstract void Work();
        public abstract void HaveDinner();
        public void GoHome()
        {
            Console.WriteLine("Go home");
        }
    }

    class LazyWorker : Worker
    {
        public override void GoToTheWork()
        {
            Console.WriteLine("Lazy go to the work");
        }

        public override void HaveDinner()
        {
            Console.WriteLine("Have a nice dinner");
        }

        public override void Work()
        {
            Console.WriteLine("Lazy work");
        }
    }

    class HardWorker : Worker
    {
        public override void GoToTheWork()
        {
            Console.WriteLine("Go hard to the work");
        }

        public override void HaveDinner()
        {
            Console.WriteLine("Have a hard dinner");
        }

        public override void Work()
        {
            Console.WriteLine("Work hard");
        }
    }
}
