using System.Collections.Generic;

namespace SimpleStackMachine
{
    public interface IStackList : IStackList<object> { }

    public interface IStackList<T> : IList<T>
    {
        T Peek();
        T Pop();
        void Push(T obj);
    }
}