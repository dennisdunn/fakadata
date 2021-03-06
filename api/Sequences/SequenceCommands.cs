﻿using EmbeddedSequences;
using Flee.PublicTypes;
using SimpleStackMachine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sequences
{
    public static class SequenceCommands
    {
        public static void Merge(IStackList<object> stack)
        {
            if (stack.HasA<IEnumerable<double>, IEnumerable<double>>())
            {
                var seq1 = stack.Pop<IEnumerable<double>>();
                var seq2 = stack.Pop<IEnumerable<double>>();
                var result = seq1.Zip(seq2, (a, b) => a + b);
                stack.Push(result);
            }
        }

        public static void Concat(IStackList<object> stack)
        {
            if (stack.HasA<IEnumerable<double>, IEnumerable<double>>())
            {
                var seq1 = stack.Pop<IEnumerable<double>>();
                var seq2 = stack.Pop<IEnumerable<double>>();
                var result = seq2.Concat(seq1);
                stack.Push(result);
            }
        }

        public static void Cycle(IStackList<object> stack)
        {
            if (stack.HasA<IEnumerable<double>>())
            {
                var seq = stack.Pop<IEnumerable<double>>();
                seq = seq.AsCycle();
                stack.Push(seq);
            }
        }

        public static void Map(IStackList<object> stack)
        {
            if (stack.HasA<string, IEnumerable<double>>())
            {
                var expr = stack.Pop<string>();
                var seq = stack.Pop<IEnumerable<double>>();

                var ctx = new ExpressionContext();
                ctx.Imports.AddType(typeof(Math));
                ctx.Imports.AddType(typeof(Probability));
                ctx.Variables["x"] = 0.0;
                var gexpr = ctx.CompileGeneric<double>(expr);

                var result = seq.Select(x =>
                {
                    ctx.Variables["x"] = x;
                    return gexpr.Evaluate();
                });
                stack.Push(result);
            }
        }

        public static void Sample(IStackList<object> stack)
        {
            if (stack.HasA<int, IEnumerable<double>>())
            {
                var limit = stack.Pop<int>();
                var seq = stack.Pop<IEnumerable<double>>();
                stack.Push(seq.Take(limit));
            }
        }

        public static void Noise(IStackList<object> stack)
        {
            var seq = SequenceFactory.From(Probability.Normal);
            stack.Push(seq);
        }

        public static void Base(IStackList<object> stack)
        {
            var x = 0;
            var seq = SequenceFactory.From(() => x++);
            stack.Push(seq);
        }

        public static void Para(IStackList<object> stack)
        {
            var x = 0;
            var seq = SequenceFactory.From(() => Math.Pow(x++, 2));
            stack.Push(seq);
        }

        public static void Saw(IStackList<object> stack)
        {
            if (stack.HasA<int>())
            {
                var x = 0;
                var width = stack.Pop<int>();
                var seq = SequenceFactory.From(() => Math.Pow(x++ % width, 2));
                stack.Push(seq);
            }
        }
    }
}
