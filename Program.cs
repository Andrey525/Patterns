namespace Patterns
{
    public static class Program
    {
        public static void Main()
        {
            /* Generative patterns */
            {
                Console.WriteLine("<FactoryMethod>");
                Generative.FactoryMethod.VehicleFactory factory = new Generative.FactoryMethod.MotoFactory();
                Generative.FactoryMethod.Vehicle vehicle = factory.Create();
                vehicle.WhoAmI();

                factory = new Generative.FactoryMethod.AutoFactory();
                vehicle = factory.Create();
                vehicle.WhoAmI();
                Console.WriteLine("</FactoryMethod>\n");

                Console.WriteLine("<AbstractFactory>");
                Generative.AbstractFactory.AbstractFactory abstractFactory = new Generative.AbstractFactory.AutoRaiderFactory();
                Generative.AbstractFactory.Enemy enemy = new Generative.AbstractFactory.Enemy(abstractFactory);

                abstractFactory = new Generative.AbstractFactory.MotoRaiderFactory();
                enemy = new Generative.AbstractFactory.Enemy(abstractFactory);
                Console.WriteLine("</AbstractFactory>\n");

                Console.WriteLine("<Singleton>");
                Generative.Singleton.Petrol petrol = Generative.Singleton.Petrol.GetInstance("AI-95");
                petrol.Print();

                petrol = Generative.Singleton.Petrol.GetInstance("AI-92");
                petrol.Print();

                Console.WriteLine("</Singleton>\n");

                Console.WriteLine("<Prototype>");
                Generative.Prototype.Prototype prototype = new Generative.Prototype.Auto("BMW");
                Generative.Prototype.Prototype clone = prototype.Clone();
                clone.Print();

                prototype = new Generative.Prototype.Moto("Harley-Davidson");
                clone = prototype.Clone();
                clone.Print();
                Console.WriteLine("</Prototype>\n");


                Console.WriteLine("<Builder>");
                Generative.Builder.Builder builder = new Generative.Builder.HardEnemyBuilder();
                builder.BuildVehicle();
                builder.BuildWeapon();
                Console.WriteLine(builder.Enemy.ToString());

                builder = new Generative.Builder.EasyEnemyBuilder();
                builder.BuildVehicle();
                builder.BuildWeapon();
                Console.WriteLine(builder.Enemy.ToString());
                Console.WriteLine("</Builder>\n");
            }

            /* Behavior patterns */
            {
                Console.WriteLine("<Strategy>");
                Behavior.Strategy.Navigator navigator = new Behavior.Strategy.Navigator(new Behavior.Strategy.FootRoute());
                navigator.BuildRoute();
                navigator.Routable = new Behavior.Strategy.CarRoute();
                navigator.BuildRoute();
                Console.WriteLine("</Strategy>\n");

                Console.WriteLine("<Observer>");
                Behavior.Observer.Car car = new Behavior.Observer.Car();
                Behavior.Observer.Driver driver = new Behavior.Observer.Driver();
                car.RegisterObserver(driver);
                car.Break();
                car.UnregisterObserver(driver);
                car.Break();
                Console.WriteLine("</Observer>\n");

                Console.WriteLine("<Command>");
                Behavior.Command.Programmer programmer = new Behavior.Command.Programmer();
                Behavior.Command.Tester tester = new Behavior.Command.Tester();
                Behavior.Command.Marketolog marketolog = new Behavior.Command.Marketolog();

                List<Behavior.Command.ICommand> commands = new List<Behavior.Command.ICommand>
                {
                    new Behavior.Command.CodeCommand(programmer),
                    new Behavior.Command.TestCommand(tester),
                    new Behavior.Command.AdvertizeCommand(marketolog)
                };
                Behavior.Command.Manager manager = new Behavior.Command.Manager();
                manager.SetCommand(new Behavior.Command.MacroCommand(commands));
                manager.StartProject();
                manager.StopProject();
                Console.WriteLine("</Command>\n");

                Console.WriteLine("<TemplateMethod>");
                Behavior.TemplateMethod.Worker worker = new Behavior.TemplateMethod.LazyWorker();
                worker.TemplateMethod();
                worker = new Behavior.TemplateMethod.HardWorker();
                worker.TemplateMethod();
                Console.WriteLine("</TemplateMEthod>\n");

                Console.WriteLine("<Iterator>");
                Behavior.Iterator.Garage garage = new Behavior.Iterator.Garage();
                Behavior.Iterator.ICarIterator iter = garage.CreateIterator();
                while (iter.HaveNext())
                {
                    Behavior.Iterator.Car c = iter.Next();
                    Console.WriteLine(c.Name);
                }
                Console.WriteLine("</Iterator>\n");

                Console.WriteLine("<Enumerator help=\"Realize IEnumerator\\IEnumerable\">");
                Behavior.Iterator.MeArray meArray = new Behavior.Iterator.MeArray();
                foreach (var elem in meArray)
                {
                    Console.WriteLine(elem.ToString());
                }
                Console.WriteLine("</Enumerator>\n");

                Console.WriteLine("<State>");
                Behavior.State.Car ca = new Behavior.State.Car(new Behavior.State.StoppedState());
                ca.StartEngine();
                ca.StopEngine();
                ca.StopEngine();
                ca.StartEngine();
                ca.StartEngine();
                ca.StopEngine();
                ca.StartEngine();
                Console.WriteLine("</State>\n");

                Console.WriteLine("<ChainOfResponsibility>");
                var singleShootHandler = new Behavior.ChainOfResponsibility.SingleShootHandler();
                var burstShootHandler = new Behavior.ChainOfResponsibility.BurstShootHandler();
                var automaticShootHandler = new Behavior.ChainOfResponsibility.AutomaticShootHandler();
                automaticShootHandler.NextHandler = burstShootHandler;
                burstShootHandler.NextHandler = singleShootHandler;
                Behavior.ChainOfResponsibility.Gun gun = new Behavior.ChainOfResponsibility.Gun(singleShootSupport: true, burstShootSupport: true, automaticShootSupport: false, automaticShootHandler);
                gun.Fire();
                Console.WriteLine("</ChainOfResponsibility>\n");

                Console.WriteLine("<Interpreter>");
                Behavior.Interpreter.Context context = new Behavior.Interpreter.Context();
                context.SetVariable("X", 10);
                context.SetVariable("Y", 15);
                context.SetVariable("Z", 10);
                Behavior.Interpreter.IExpression expr = new Behavior.Interpreter.SubExpression(new Behavior.Interpreter.SubExpression(new Behavior.Interpreter.NumberExpression("X"),
                                                                                                                                  new Behavior.Interpreter.NumberExpression("Y")),
                                                                                               new Behavior.Interpreter.NumberExpression("Z"));
                Console.WriteLine(expr.Interpret(context));
                Console.WriteLine("</Interpreter>\n");
            }
        }
    }
}