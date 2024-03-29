﻿namespace Patterns
{
    public static class Program
    {
        public static void Main()
        {
            /* Generative patterns */
            {
                Console.WriteLine("<FactoryMethod>");
                Generative.FactoryMethod.VehicleFactory factory = new Generative.FactoryMethod.MotoFactory();
                Generative.FactoryMethod.Vehicle vehicle = factory.Create();
                vehicle.WhoAmI();

                factory = new Generative.FactoryMethod.AutoFactory();
                vehicle = factory.Create();
                vehicle.WhoAmI();
                Console.WriteLine("</FactoryMethod>\n");

                Console.WriteLine("<AbstractFactory>");
                Generative.AbstractFactory.AbstractFactory abstractFactory = new Generative.AbstractFactory.AutoRaiderFactory();
                Generative.AbstractFactory.Enemy enemy = new Generative.AbstractFactory.Enemy(abstractFactory);

                abstractFactory = new Generative.AbstractFactory.MotoRaiderFactory();
                enemy = new Generative.AbstractFactory.Enemy(abstractFactory);
                Console.WriteLine("</AbstractFactory>\n");

                Console.WriteLine("<Singleton>");
                Generative.Singleton.Petrol petrol = Generative.Singleton.Petrol.GetInstance("AI-95");
                petrol.Print();

                petrol = Generative.Singleton.Petrol.GetInstance("AI-92");
                petrol.Print();

                Console.WriteLine("</Singleton>\n");

                Console.WriteLine("<Prototype>");
                Generative.Prototype.Prototype prototype = new Generative.Prototype.Auto("BMW");
                Generative.Prototype.Prototype clone = prototype.Clone();
                clone.Print();

                prototype = new Generative.Prototype.Moto("Harley-Davidson");
                clone = prototype.Clone();
                clone.Print();
                Console.WriteLine("</Prototype>\n");


                Console.WriteLine("<Builder>");
                Generative.Builder.Builder builder = new Generative.Builder.HardEnemyBuilder();
                builder.BuildVehicle();
                builder.BuildWeapon();
                Console.WriteLine(builder.Enemy.ToString());

                builder = new Generative.Builder.EasyEnemyBuilder();
                builder.BuildVehicle();
                builder.BuildWeapon();
                Console.WriteLine(builder.Enemy.ToString());
                Console.WriteLine("</Builder>\n");
            }

            /* Behavior patterns */
            {
                Console.WriteLine("<Strategy>");
                Behavior.Strategy.Navigator navigator = new Behavior.Strategy.Navigator(new Behavior.Strategy.FootRoute());
                navigator.BuildRoute();
                navigator.Routable = new Behavior.Strategy.CarRoute();
                navigator.BuildRoute();
                Console.WriteLine("</Strategy>\n");

                Console.WriteLine("<Observer>");
                Behavior.Observer.Car car = new Behavior.Observer.Car();
                Behavior.Observer.Driver driver = new Behavior.Observer.Driver();
                car.RegisterObserver(driver);
                car.Break();
                car.UnregisterObserver(driver);
                car.Break();
                Console.WriteLine("</Observer>\n");

                Console.WriteLine("<Command>");
                Behavior.Command.Programmer programmer = new Behavior.Command.Programmer();
                Behavior.Command.Tester tester = new Behavior.Command.Tester();
                Behavior.Command.Marketolog marketolog = new Behavior.Command.Marketolog();

                List<Behavior.Command.ICommand> commands = new List<Behavior.Command.ICommand>
                {
                    new Behavior.Command.CodeCommand(programmer),
                    new Behavior.Command.TestCommand(tester),
                    new Behavior.Command.AdvertizeCommand(marketolog)
                };
                Behavior.Command.Manager manager = new Behavior.Command.Manager();
                manager.SetCommand(new Behavior.Command.MacroCommand(commands));
                manager.StartProject();
                manager.StopProject();
                Console.WriteLine("</Command>\n");

                Console.WriteLine("<TemplateMethod>");
                Behavior.TemplateMethod.Worker worker = new Behavior.TemplateMethod.LazyWorker();
                worker.TemplateMethod();
                worker = new Behavior.TemplateMethod.HardWorker();
                worker.TemplateMethod();
                Console.WriteLine("</TemplateMEthod>\n");

                Console.WriteLine("<Iterator>");
                Behavior.Iterator.Garage garage = new Behavior.Iterator.Garage();
                Behavior.Iterator.ICarIterator iter = garage.CreateIterator();
                while (iter.HaveNext())
                {
                    Behavior.Iterator.Car c = iter.Next();
                    Console.WriteLine(c.Name);
                }
                Console.WriteLine("</Iterator>\n");

                Console.WriteLine("<Enumerator help=\"Realize IEnumerator\\IEnumerable\">");
                Behavior.Iterator.MeArray meArray = new Behavior.Iterator.MeArray();
                foreach (var elem in meArray)
                {
                    Console.WriteLine(elem.ToString());
                }
                Console.WriteLine("</Enumerator>\n");

                Console.WriteLine("<State>");
                Behavior.State.Car ca = new Behavior.State.Car(new Behavior.State.StoppedState());
                ca.StartEngine();
                ca.StopEngine();
                ca.StopEngine();
                ca.StartEngine();
                ca.StartEngine();
                ca.StopEngine();
                ca.StartEngine();
                Console.WriteLine("</State>\n");

                Console.WriteLine("<ChainOfResponsibility>");
                var singleShootHandler = new Behavior.ChainOfResponsibility.SingleShootHandler();
                var burstShootHandler = new Behavior.ChainOfResponsibility.BurstShootHandler();
                var automaticShootHandler = new Behavior.ChainOfResponsibility.AutomaticShootHandler();
                automaticShootHandler.NextHandler = burstShootHandler;
                burstShootHandler.NextHandler = singleShootHandler;
                Behavior.ChainOfResponsibility.Gun gun = new Behavior.ChainOfResponsibility.Gun(singleShootSupport: true, burstShootSupport: true, automaticShootSupport: false, automaticShootHandler);
                gun.Fire();
                Console.WriteLine("</ChainOfResponsibility>\n");

                Console.WriteLine("<Interpreter>");
                Behavior.Interpreter.Context context = new Behavior.Interpreter.Context();
                context.SetVariable("X", 10);
                context.SetVariable("Y", 15);
                context.SetVariable("Z", 10);
                Behavior.Interpreter.IExpression expr = new Behavior.Interpreter.SubExpression(new Behavior.Interpreter.SubExpression(new Behavior.Interpreter.NumberExpression("X"),
                                                                                                                                  new Behavior.Interpreter.NumberExpression("Y")),
                                                                                               new Behavior.Interpreter.NumberExpression("Z"));
                Console.WriteLine(expr.Interpret(context));
                Console.WriteLine("</Interpreter>\n");

                Console.WriteLine("<Mediator>");
                var mediator = new Behavior.Mediator.ManagerMediator();
                Behavior.Mediator.Colleague customer = new Behavior.Mediator.CustomerColleague(mediator);
                Behavior.Mediator.Colleague prog = new Behavior.Mediator.ProgrammerColleague(mediator);
                Behavior.Mediator.Colleague test = new Behavior.Mediator.TesterColleague(mediator);
                mediator.Customer = customer;
                mediator.Programmer = prog;
                mediator.Tester = test;
                customer.Send("I need new feature!");
                prog.Send("New feature is ready!");
                test.Send("Damn! It works wrong!");

                Console.WriteLine("</Mediator>\n");

                Console.WriteLine("<Memento>");
                Behavior.Memento.Hero hero = new Behavior.Memento.Hero();
                hero.Shoot();
                Behavior.Memento.GameHistory game = new Behavior.Memento.GameHistory();
                game.History.Push(hero.SaveState());
                hero.Shoot();
                hero.RestoreState(game.History.Pop());
                hero.Shoot();
                Console.WriteLine("</Memento>\n");

                Console.WriteLine("<Visitor>");
                Behavior.Visitor.IAccept[] array = { new Behavior.Visitor.Car(), new Behavior.Visitor.Moto() };

                Behavior.Visitor.IVisitor visitor = new Behavior.Visitor.RepairVisitor();
                foreach (var elem in array)
                {
                    elem.Accept(visitor);
                }
                visitor = new Behavior.Visitor.PaintVisitor();
                foreach (var elem in array)
                {
                    elem.Accept(visitor);
                }
                Console.WriteLine("</Visitor>\n");

                /* Structural patterns */
                Console.WriteLine("<Decorator>");
                Structural.Decorator.House house = new Structural.Decorator.StoneHouse();
                house.ShowInfo();
                house = new Structural.Decorator.HouseWithPool(house);
                house.ShowInfo();
                house = new Structural.Decorator.HouseWithFirePlace(house);
                house.ShowInfo();

                house = new Structural.Decorator.WoodHouse();
                house.ShowInfo();
                house = new Structural.Decorator.HouseWithPool(house);
                house.ShowInfo();
                house = new Structural.Decorator.HouseWithFirePlace(house);
                house.ShowInfo();
                Console.WriteLine("</Decorator>\n");

                Console.WriteLine("<Adapter>");
                Structural.Adapter.Weapon weapon = new Structural.Adapter.Sword();
                Structural.Adapter.Teeth teeth = new Structural.Adapter.Teeth();
                Structural.Adapter.Knight knight = new Structural.Adapter.Knight();
                knight.Hit(weapon);
                weapon = new Structural.Adapter.TeethToWeaponAdapter(teeth);
                knight.Hit(weapon);
                Console.WriteLine("</Adapter>\n");

                Console.WriteLine("<Facade>");
                Structural.Facade.Algorithm1 alg1 = new Structural.Facade.Algorithm1();
                Structural.Facade.Algorithm2 alg2 = new Structural.Facade.Algorithm2();
                Structural.Facade.AlgFacade alg = new Structural.Facade.AlgFacade(alg1, alg2);
                alg.Start();
                Console.WriteLine("</Facade>\n");

                Console.WriteLine("<Composite>");
                Structural.Composite.Component comp1 = new Structural.Composite.Composite("Root");
                Structural.Composite.Component comp2 = new Structural.Composite.Composite("Clients");
                Structural.Composite.Component comp2_1 = new Structural.Composite.Leaf("Client 1");
                Structural.Composite.Component comp2_2 = new Structural.Composite.Leaf("Client 2");
                Structural.Composite.Component comp3 = new Structural.Composite.Composite("Servers");
                Structural.Composite.Component comp3_1 = new Structural.Composite.Leaf("Server 1");
                Structural.Composite.Component comp4 = new Structural.Composite.Leaf("Manager");
                comp1.Add(comp2);
                comp1.Add(comp3);
                comp1.Add(comp4);
                comp2.Add(comp2_1);
                comp2.Add(comp2_2);
                comp3.Add(comp3_1);
                comp1.Display();
                Console.WriteLine("</Composite>\n");

                Console.WriteLine("<Proxy>");
                Structural.Proxy.IBook book = new Structural.Proxy.BookStoreProxy();
                Structural.Proxy.Page page1 = book.GetPage(1);
                Console.WriteLine(page1.Text);
                Structural.Proxy.Page page2 = book.GetPage(2);
                Console.WriteLine(page2.Text);
                page1 = book.GetPage(1);
                Console.WriteLine(page1.Text);
                Console.WriteLine("</Proxy>\n");
            }
        }
    }
}