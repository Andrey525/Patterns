namespace Patterns.Generative.AbstractFactory
{
    abstract class AbstractFactory
    {
        public abstract Vehicle CreateVehicle();
        public abstract Weapon CreateWeapon();
    }

    class MotoRaiderFactory : AbstractFactory
    {
        public override Vehicle CreateVehicle()
        {
            return new Moto();
        }
        public override Weapon CreateWeapon()
        {
            return new Gun();
        }
    }

    class AutoRaiderFactory : AbstractFactory
    {
        public override Vehicle CreateVehicle()
        {
            return new Auto();
        }
        public override Weapon CreateWeapon()
        {
            return new ShotGun();
        }
    }

    abstract class Vehicle
    {
        public abstract override string ToString();
    }

    class Moto : Vehicle
    {
        public override string ToString()
        {
            return "Moto";
        }
    }

    class Auto : Vehicle
    {
        public override string ToString()
        {
            return "Auto";
        }
    }

    abstract class Weapon
    {
        public abstract override string ToString();
    }

    class Gun : Weapon
    {
        public override string ToString()
        {
            return "Gun";
        }
    }

    class ShotGun : Weapon
    {
        public override string ToString()
        {
            return "ShotGun";
        }
    }

    class Enemy
    {
        Weapon _weapon;
        Vehicle _vehicle;

        public Enemy(AbstractFactory factory)
        {
            _weapon = factory.CreateWeapon();
            _vehicle = factory.CreateVehicle();

            Console.WriteLine($"I am enemy on {_vehicle.ToString()} with {_weapon.ToString()}");
        }
    }
}
