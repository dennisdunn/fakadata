using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStackMachine
{
    public class IndexStack<T> : List<T>
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
