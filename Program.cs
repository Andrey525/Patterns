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

            }
        }
    }
}