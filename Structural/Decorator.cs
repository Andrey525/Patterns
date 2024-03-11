namespace Patterns.Structural.Decorator
{
    abstract class House
    {
        public string Type { get; set; }
        public House(string type)
        {
            Type = type;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"House type: {Type}; Cost: {GetCost().ToString()}");
        }

        public abstract int GetCost();
    }

    abstract class Decorator : House
    {
        protected House house;
        protected Decorator(string type, House house) : base(type)
        {
            this.house = house;
        }
    }

    class StoneHouse : House
    {
        public StoneHouse() : base("Stone house")
        {

        }

        public override int GetCost()
        {
            return 250_000;
        }
    }

    class WoodHouse : House
    {
        public WoodHouse() : base("Wood house")
        {

        }

        public override int GetCost()
        {
            return 150_000;
        }
    }

    class HouseWithPool : Decorator
    {
        public HouseWithPool(House house) : base(house.Type + " with pool", house) { }

        public override int GetCost()
        {
            return house.GetCost() + 50_000;
        }
    }
    class HouseWithFirePlace : Decorator
    {
        public HouseWithFirePlace(House house) : base(house.Type + " with fire place", house) { }

        public override int GetCost()
        {
            return house.GetCost() + 25_000;
        }
    }
}
