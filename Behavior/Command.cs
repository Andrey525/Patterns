namespace Patterns.Behavior.Command
{
    interface ICommand
    {
        void Execute();
        void Undo();
    }
    class MacroCommand : ICommand
    {
        List<ICommand> commands;
        public MacroCommand(List<ICommand> coms)
        {
            commands = coms;
        }
        public void Execute()
        {
            foreach (ICommand c in commands)
                c.Execute();
        }

        public void Undo()
        {
            foreach (ICommand c in commands)
                c.Undo();
        }
    }

    class Programmer
    {
        public void StartCoding()
        {
            Console.WriteLine("Programmer starts writing code");
        }
        public void StopCoding()
        {
            Console.WriteLine("Programmer stops writing code");
        }
    }

    class Tester
    {
        public void StartTest()
        {
            Console.WriteLine("QA starts testing");
        }
        public void StopTest()
        {
            Console.WriteLine("QA stops testing");
        }
    }

    class Marketolog
    {
        public void StartAdvertize()
        {
            Console.WriteLine("Marketer starts advertising");
        }
        public void StopAdvertize()
        {
            Console.WriteLine("Marketer stops advertising");
        }
    }

    class CodeCommand : ICommand
    {
        Programmer programmer;
        public CodeCommand(Programmer p)
        {
            programmer = p;
        }
        public void Execute()
        {
            programmer.StartCoding();
        }
        public void Undo()
        {
            programmer.StopCoding();
        }
    }

    class TestCommand : ICommand
    {
        Tester tester;
        public TestCommand(Tester t)
        {
            tester = t;
        }
        public void Execute()
        {
            tester.StartTest();
        }
        public void Undo()
        {
            tester.StopTest();
        }
    }

    class AdvertizeCommand : ICommand
    {
        Marketolog marketolog;
        public AdvertizeCommand(Marketolog m)
        {
            marketolog = m;
        }
        public void Execute()
        {
            marketolog.StartAdvertize();
        }

        public void Undo()
        {
            marketolog.StopAdvertize();
        }
    }

    class Manager
    {
        ICommand command;
        public void SetCommand(ICommand com)
        {
            command = com;
        }
        public void StartProject()
        {
            if (command != null)
                command.Execute();
        }
        public void StopProject()
        {
            if (command != null)
                command.Undo();
        }
    }
}