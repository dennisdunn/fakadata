using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SimpleStackMachine
{
    public class StackMachine : IStackMachine
    {
        internal StackList<object> _stack = new StackList<object>();
        internal Dictionary<string, MethodInfo> _commands = new Dictionary<string, MethodInfo>(StringComparer.OrdinalIgnoreCase);

        public StackList<object> Context => _stack;

        public IEnumerable<string> Commands => _commands.Keys;

        public StackMachine()
        {
            Register(Assembly.GetExecutingAssembly());
        }

        public StackMachine(params Type[] types) : this()
        {
            foreach (var type in types)
            {
                Register(type);
            }
        }

        public void Register<T>()
        {
            Register(typeof(T).Assembly);
        }

        public void Register(Type t)
        {
            Register(t.Assembly);
        }

        public void Register(Assembly assembly)
        {
            foreach (var t in assembly.GetTypes().Where(t => t.IsClass && t.IsAbstract && t.IsSealed))
                foreach (var m in t.GetMethods(BindingFlags.Public | BindingFlags.Static))
                {
                    if (m.ReturnType == typeof(void)
                        && m.GetParameters().Count() == 1
                        && m.GetParameters().Any(x => x.ParameterType == typeof(IStackList<object>)))
                    {
                        _commands[m.Name] = m;
                    }
                }
        }

        public void Eval(string text)
        {
            if (_commands.ContainsKey(text))
            {
                var info = _commands[text];
                info.Invoke(info, new[] { _stack });
            }
            else
            {
                if (int.TryParse(text, out int i))
                {
                    _stack.Push(i);
                }
                else if (double.TryParse(text, out double d))
                {
                    _stack.Push(d);
                }
                else if (DateTime.TryParse(text, out DateTime dt))
                {
                    _stack.Push(dt);
                }
                else if (bool.TryParse(text, out bool b))
                {
                    _stack.Push(b);
                }
                else
                {
                    _stack.Push(text);
                }
            }
        }

        public void Eval(IEnumerable<string> text)
        {
            foreach (var t in text)
            {
                Eval(t);
            }
        }

        public void Eval(TextReader reader)
        {
            string text;
            while ((text = reader.ReadLine()) != null)
            {
                Eval(text);
            }
        }

        public void Reset()
        {
            _stack.Clear();
        }
    }
}