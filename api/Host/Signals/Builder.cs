using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Timeseries.Api.Signals
{
    public enum Commands
    {
        Cardinal,
        Parabola,
        Noise,
        Fetch,
        Combine,
        Concat,
        Apply,
        Limit
    }

    public class Builder
    {
        private readonly Stack<object> _stack = new Stack<object>();

        public IEnumerable<double> Build()
        {
            return (IEnumerable<double>)_stack.Pop();
        }

        public void Do(Commands cmd)
        {
            switch (cmd)
            {
                case Commands.Cardinal:
                    _stack.Push(SignalFactory.Cardinal());
                    break;
                case Commands.Parabola:
                    _stack.Push(SignalFactory.Parabola());
                    break;
                case Commands.Noise:
                    _stack.Push(SignalFactory.Noise());
                    break;
                case Commands.Fetch:
                    {
                        var a = (string)_stack.Pop();
                        _stack.Push(SignalFactory.FromCatalog(a));
                    }
                    break;
                case Commands.Combine:
                    {
                        var b = (IEnumerable<double>)_stack.Pop();
                        var a = (IEnumerable<double>)_stack.Pop();
                        _stack.Push(a.Zip(b, (m, n) => m + n));
                    }
                    break;
                case Commands.Concat:
                    {
                        var b = (IEnumerable<double>)_stack.Pop();
                        var a = (IEnumerable<double>)_stack.Pop();
                        _stack.Push(a.Concat(b));
                    }
                    break;
                case Commands.Apply:
                    {
                        var b = (string)_stack.Pop();
                        var a = (IEnumerable<double>)_stack.Pop();
                        _stack.Push(a.Select(b));
                    }
                    break;
                case Commands.Limit:
                    {
                        var b = (double)_stack.Pop();
                        var a = (IEnumerable<double>)_stack.Pop();
                        _stack.Push(a.Take((int)Math.Truncate(b)));
                    }
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        public void Interpret(TextReader reader)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (Enum.TryParse<Commands>(line, true, out Commands cmd) && Enum.IsDefined(typeof(Commands), cmd))
                {
                    Do(cmd);
                }
                else if (double.TryParse(line, out double value))
                {
                    _stack.Push(value);
                }
                else
                {
                    _stack.Push(line);
                }
            }
        }

        public void Interpret(string source)
        {
            var reader = new StringReader(source);
            Interpret(reader);
        }
    }
}
