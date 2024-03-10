namespace Patterns.Behavior.Interpreter
{
    class Context
    {
        Dictionary<string, int> _variables;

        public Context()
        {
            _variables = new Dictionary<string, int>();
        }

        public int GetVariable(string name)
        {
            return _variables[name];
        }

        public void SetVariable(string name, int value)
        {
            _variables[name] = value;
        }
    }

    interface IExpression
    {
        int Interpret(Context context);
    }

    class NumberExpression : IExpression
    {
        string _name { get; set; }
        public NumberExpression(string name)
        {
            _name = name;
        }
        public int Interpret(Context context)
        {
            return context.GetVariable(_name);
        }
    }

    class SubExpression : IExpression
    {
        IExpression _left;
        IExpression _right;
        public SubExpression(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }
        public int Interpret(Context context)
        {
            return _left.Interpret(context) - _right.Interpret(context);
        }
    }
}
