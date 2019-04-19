using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStackMachine
{
    public class StackList : StackList<object> { }

    public class StackList<T> : List<T>, IStackList<T>
    {
        public void Push(T obj)
        {
            Insert(0, obj);
        }

        public T Pop()
        {
            T obj = Peek();
            Remove(obj);
            return obj;
        }

        public T Peek()
        {
            return Count > 0
                ? this[0]
                : default;
        }
    }
}
