namespace Patterns.Structural.Composite
{
    abstract class Component
    {
        protected string name;
        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public abstract void Display();
    }

    class Composite : Component
    {
        List<Component> _components;

        public Composite(string name) : base(name) { _components = new List<Component>(); }
        public override void Add(Component component)
        {
            _components.Add(component);
        }

        public override void Display()
        {
            Console.WriteLine(name);
            foreach (var elem in _components)
            {
                elem.Display();
            }
        }

        public override void Remove(Component component)
        {
            _components.Remove(component);
        }
    }

    class Leaf : Component
    {
        public Leaf(string name) : base(name) { }
        public override void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public override void Display()
        {
            Console.WriteLine(this.name);
        }

        public override void Remove(Component component)
        {
            throw new NotImplementedException();
        }
    }
}
