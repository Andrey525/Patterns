using System.Collections;

namespace Patterns.Behavior.Iterator
{
    class Car
    {
        public string Name { get; set; }
    }
    interface ICarIterator
    {
        bool HaveNext();
        Car Next();

    }
    interface ICarNumerable
    {
        ICarIterator CreateIterator();
        int Count { get; }
        Car this[int index] { get; }
    }

    class Garage : ICarNumerable
    {
        Car[] _cars;

        public Garage()
        {
            _cars = new Car[]
            {
                new Car { Name="BMW" },
                new Car { Name="Mercedes" },
                new Car { Name="Volvo" }
            };
        }
        public Car this[int index] => _cars[index];

        public int Count => _cars.Length;

        public ICarIterator CreateIterator()
        {
            return new GarageIterator(this);
        }
    }

    class GarageIterator : ICarIterator
    {
        ICarNumerable _garage;
        int _index;
        public GarageIterator(ICarNumerable garage)
        {
            _garage = garage;
            _index = 0;
        }
        public bool HaveNext()
        {
            return _index < _garage.Count;
        }

        public Car Next()
        {
            return _garage[_index++];
        }
    }


    class MeArray : IEnumerable
    {
        int[] _array;
        public int Count { get { return _array.Length; } }

        public int this[int index] { get { return _array[index]; } }

        public MeArray()
        {
            _array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        }
        public IEnumerator GetEnumerator()
        {
            return new MeIterator(this);
        }
    }

    class MeIterator : IEnumerator
    {
        public MeArray _obj;
        int _index;
        public MeIterator(MeArray obj)
        {
            _obj = obj;
            _index = -1;
        }
        public object Current => _obj[_index];

        public bool MoveNext()
        {
            if (_index < _obj.Count - 1)
            {
                _index++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _index = -1;
        }
    }
}
