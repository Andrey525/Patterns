namespace Patterns.Generative.Builder
{
    abstract class Builder
    {
        public Enemy Enemy { get; private set; }

        public Builder()
        {
            Enemy = new Enemy();
        }

        public abstract void BuildWeapon();
        public abstract void BuildVehicle();
    }

    class EasyEnemyBuilder : Builder
    {
        public override void BuildWeapon()
        {
            Enemy.Weapon = new Gun();
        }
        public override void BuildVehicle()
        {
            Enemy.Vehicle = new Moto();
        }
    }

    class HardEnemyBuilder : Builder
    {
        public override void BuildWeapon()
        {
            Enemy.Weapon = new ShotGun();
        }
        public override void BuildVehicle()
        {
            Enemy.Vehicle = new Auto();
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
        public Weapon Weapon { get; set; }
        public Vehicle Vehicle { get; set; }

        public override string ToString()
        {
            return $"Enemy with {Weapon.ToString()} on {Vehicle.ToString()}";
        }
    }
}
