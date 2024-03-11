namespace Patterns.Structural.Adapter
{
    class Knight
    {
        public void Hit(Weapon weapon)
        {
            weapon.Attack();
        }
    }

    abstract class Weapon
    {
        public abstract void Attack();
    }

    class Sword : Weapon
    {
        public override void Attack()
        {
            Console.WriteLine($"Attack by Sword");
        }
    }

    class Teeth
    {
        public void Bite()
        {
            Console.WriteLine($"Bite by Teeth");
        }
    }

    class TeethToWeaponAdapter : Weapon
    {
        Teeth _teeth;
        public TeethToWeaponAdapter(Teeth teeth)
        {
            _teeth = teeth;
        }

        public override void Attack()
        {
            _teeth.Bite();
        }
    }
}
