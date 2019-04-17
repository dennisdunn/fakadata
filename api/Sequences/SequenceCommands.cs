using Flee.PublicTypes;
using SimpleStackMachine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sequences
{
    public static class SequenceCommands
    {
       public static void Load(IStackList<object> stack)
        {
            var key = stack.PopAs<string>();
            var seq = SequenceFactory.Load(key);
            stack.Push(seq);
        }

       public static void List(IStackList<object> stack)
        {
            var list = SequenceFactory.List();
            stack.PushRange(list);
        }

       public static void Merge(IStackList<object> stack)
        {
            var seq1 = stack.Pop() as IEnumerable<double>;
            var seq2 = stack.Pop() as IEnumerable<double>;
            var result = seq1.Zip(seq2, (a, b) => a + b);
            stack.Push(result);
        }

       public static void Concat(IStackList<object> stack)
        {
            var seq1 = stack.Pop() as IEnumerable<double>;
            var seq2 = stack.Pop() as IEnumerable<double>;
            var result = seq2.Concat(seq1);
            stack.Push(result);
        }

       public static void Map(IStackList<object> stack)
        {
            var expr = stack.PopAs<string>();
            var seq = stack.Pop() as IEnumerable<double>;

            var ctx = new ExpressionContext();
            ctx.Imports.AddType(typeof(Math));
            ctx.Variables["x"]=0.0;
            var gexpr = ctx.CompileGeneric<double>(expr);

            var result = seq.Select(x =>
            {
                ctx.Variables["x"] = x;
                return gexpr.Evaluate();
            });
            stack.Push(result);
        }

       public static void Limit(IStackList<object> stack)
        {
            var limit = stack.PopAs<int>();
            var seq = stack.Pop() as IEnumerable<double>;
            stack.Push(seq.Take(limit));
        }

       public static void Noise(IStackList<object> stack)
        {
            var seq = SequenceFactory.From(Probability.Normal);
            stack.Push(seq);
        }

       public static void Cardinals(IStackList<object> stack)
        {
            var i = 0;
            var seq = SequenceFactory.From(() => i++);
            stack.Push(seq);
        }
    }
}
