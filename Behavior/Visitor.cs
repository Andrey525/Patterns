namespace Patterns.Behavior.Visitor
{
    interface IAccept
    {
        void Accept(IVisitor visitor);
    }
    class Car : IAccept
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitCar(this);
        }
    }

    class Moto : IAccept
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitMoto(this);
        }
    }
    interface IVisitor
    {
        void VisitCar(Car car);
        void VisitMoto(Moto moto);
    }

    class RepairVisitor : IVisitor
    {
        public void VisitCar(Car car)
        {
            Console.WriteLine("Repair 4 wheels");
        }

        public void VisitMoto(Moto moto)
        {
            Console.WriteLine("Repair 2 wheels");
        }
    }

    class PaintVisitor : IVisitor
    {
        public void VisitCar(Car car)
        {
            Console.WriteLine("Paint car");
        }

        public void VisitMoto(Moto moto)
        {
            Console.WriteLine("Paint moto");
        }
    }
}
