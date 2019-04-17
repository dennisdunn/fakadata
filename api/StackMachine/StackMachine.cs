using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SimpleStackMachine
{
    public class StackMachine
    {
        internal IndexStack<object> _stack = new IndexStack<object>();
        internal Dictionary<string, TypeInfo> _commands = new Dictionary<string, TypeInfo>(StringComparer.OrdinalIgnoreCase);

        public IndexStack<object> Context => _stack;

        public StackMachine()
        {
            var assembly = Assembly.GetExecutingAssembly();
            Register(assembly);
        }

        public void Register(Assembly assembly)
        {
            foreach (var t in assembly.DefinedTypes.Where(t => typeof(ICommand).IsAssignableFrom(t)))
            {
                _commands[t.Name] = t;
            }
        }

        public void Eval(params string[] text)
        {
            foreach (var src in text)
            {
                if (_commands.ContainsKey(src))
                {
                    var info = _commands[src];
                    var cmd = (ICommand)Activator.CreateInstance(info.AsType());
                    cmd.Run(_stack);
                }
                else
                {
                    _stack.Push(src);
                }
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
    }
}