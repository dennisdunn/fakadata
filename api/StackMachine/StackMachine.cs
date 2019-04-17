using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SimpleStackMachine
{
    public class StackMachine
    {
        internal StackList<object> _stack = new StackList<object>();
        internal Dictionary<string, MethodInfo> _commands = new Dictionary<string, MethodInfo>(StringComparer.OrdinalIgnoreCase);

        public StackList<object> Context => _stack;

        public StackMachine()
        {
            Assembly[] assemblies = {
                Assembly.GetExecutingAssembly(),
                Assembly.GetCallingAssembly(),
                Assembly.GetEntryAssembly()
            };

            Register(assemblies);
        }

        public void Register(params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
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

        public void Eval(params string[] text)
        {
            foreach (var src in text)
            {
                if (_commands.ContainsKey(src))
                {
                    var info = _commands[src];
                    info.Invoke(info, new[] { _stack });
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