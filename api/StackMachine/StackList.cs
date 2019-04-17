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
            var obj = this[0];
            Remove(obj);

            return obj;
        }

        public T Peek()
        {
            return this[0];
        }
    }
}
