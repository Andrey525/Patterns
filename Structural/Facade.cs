namespace Patterns.Structural.Facade
{
    class Algorithm1
    {
        public void Step1()
        {
            Console.WriteLine("Algorithm1 Step1");
        }

        public void Step2()
        {
            Console.WriteLine("Algorithm1 Step2");
        }
    }

    class Algorithm2
    {
        public void Step1()
        {
            Console.WriteLine("Algorithm2 Step1");
        }

        public void Step2()
        {
            Console.WriteLine("Algorithm2 Step2");
        }
    }

    class AlgFacade
    {
        Algorithm1 _alg1;
        Algorithm2 _alg2;

        public AlgFacade(Algorithm1 alg1, Algorithm2 alg2)
        {
            _alg1 = alg1;
            _alg2 = alg2;
        }

        public void Start()
        {
            _alg1.Step1();
            _alg2.Step1();
            _alg1.Step2();
            _alg2.Step2();
        }
    }
}
