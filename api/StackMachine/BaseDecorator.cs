using SimpleStackMachine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SimpleStackMachine
{
    public abstract class BaseDecorator : IStackMachine
    {
        protected readonly IStackMachine _target;

        public IEnumerable<string> Commands => _target.Commands;

        public StackList<object> Context => _target.Context;

        private BaseDecorator() { }

        public BaseDecorator(IStackMachine target)
        {
            _target = target;
        }

        public virtual void Eval(string text)
        {
            _target.Eval(text);
        }

        public virtual void Eval(IEnumerable<string> text)
        {
            _target.Eval(text);
        }

        public virtual void Eval(TextReader reader)
        {
            _target.Eval(reader);
        }

        public virtual void Register(Assembly assembly)
        {
            _target.Register(assembly);
        }

        public virtual void Register(Type t)
        {
            _target.Register(t);
        }

        public virtual void Register<T>()
        {
            _target.Register<T>();
        }

        public virtual void Reset()
        {
            _target.Reset();
        }
    }
}
