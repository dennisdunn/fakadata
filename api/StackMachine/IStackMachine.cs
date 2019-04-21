using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SimpleStackMachine
{
    public interface IStackMachine
    {
        IEnumerable<string> Commands { get; }
        StackList<object> Context { get; }

        void Eval(string text);
        void Eval(IEnumerable<string> text);
        void Eval(TextReader reader);
        void Register(Assembly assembly);
        void Register(Type t);
        void Register<T>();
        void Reset();
    }
}