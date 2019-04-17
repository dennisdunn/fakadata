using Flee.PublicTypes;
using SimpleStackMachine;
using System.Collections.Generic;
using System.Linq;

namespace Sequences
{
    public class Load : ICommand
    {
        public void Run(IndexStack<object> stack)
        {
            var key = stack.Pop<string>();
            var seq = SequenceFactory.Load(key);
            stack.Push(seq);
        }
    }

    public class List : ICommand
    {
        public void Run(IndexStack<object> stack)
        {
            var list = SequenceFactory.List();
            stack.PushRange(list);
        }
    }

    public class Merge : ICommand
    {
        public void Run(IndexStack<object> stack)
        {
            var seq1 = stack.Pop() as IEnumerable<double>;
            var seq2 = stack.Pop() as IEnumerable<double>;
            var result = seq1.Zip(seq2, (a, b) => a + b);
            stack.Push(result);
        }
    }

    public class Concat : ICommand
    {
        public void Run(IndexStack<object> stack)
        {
            var seq1 = stack.Pop() as IEnumerable<double>;
            var seq2 = stack.Pop() as IEnumerable<double>;
            var result = seq2.Concat(seq1);
            stack.Push(result);
        }
    }

    public class Map : ICommand
    {
        public void Run(IndexStack<object> stack)
        {
            var expr = stack.Pop<string>();
            var seq = stack.Pop() as IEnumerable<double>;

            var ctx = new ExpressionContext();
            var gexpr = ctx.CompileGeneric<double>(expr);

            var result = seq.Select(x =>
            {
                ctx.Variables["x"] = x;
                return gexpr.Evaluate();
            });
            stack.Push(result);
        }
    }

    public class Limit : ICommand
    {
        public void Run(IndexStack<object> stack)
        {
            var limit = stack.Pop<int>();
            var seq = stack.Pop() as IEnumerable<double>;
            stack.Push(seq.Take(limit));
        }
    }

    public class Noise : ICommand
    {
        public void Run(IndexStack<object> stack)
        {
            var seq = SequenceFactory.From(Probability.Normal);
            stack.Push(seq);
        }
    }

    public class Cardinals : ICommand
    {
        public void Run(IndexStack<object> stack)
        {
            var i = 0;
            var seq = SequenceFactory.From(() => i++);
            stack.Push(seq);
        }
    }
}
