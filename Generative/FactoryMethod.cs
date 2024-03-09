namespace Patterns.Generative.FactoryMethod
{
    abstract class VehicleFactory
    {
        public abstract Vehicle Create();
    }

    class MotoFactory : VehicleFactory
    {
        public override Vehicle Create()
        {
            return new Moto();
        }
    }

    class AutoFactory : VehicleFactory
    {
        public override Vehicle Create()
        {
            return new Auto();
        }
    }

    abstract class Vehicle
    {
        public abstract void WhoAmI();
    }

    class Moto : Vehicle
    {
        public override void WhoAmI()
        {
            Console.WriteLine("I am Moto");
        }
    }

    class Auto : Vehicle
    {
        public override void WhoAmI()
        {
            Console.WriteLine("I am Auto");
        }
    }

}
