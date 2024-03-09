namespace Patterns.Generative.Prototype
{
    abstract class Prototype
    {
        public string Name { get; private set; }

        public void Print()
        {
            Console.WriteLine(Name);
        }

        public Prototype(string name)
        {
            Name = name;
        }
        public abstract Prototype Clone();
    }

    class Auto : Prototype
    {
        public Auto(string name) : base(name) { }
        public override Prototype Clone()
        {
            return new Auto(Name);
        }
    }

    class Moto : Prototype
    {
        public Moto(string name) : base(name) { }
        public override Prototype Clone()
        {
            return new Moto(Name);
        }
    }
}
