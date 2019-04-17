using System;
using System.Collections.Generic;

namespace SimpleStackMachine
{
    public static class Extensions
    {
        public static T Pop<T>(this IndexStack<object> stack)
        {
            var obj = stack.Pop();
            var result = Convert.ChangeType(obj, typeof(T));
            return (T)result;
        }
        
        public static void PushRange<T>(this IndexStack<object> stack, IEnumerable<T> collection)
        {
            foreach(var obj in collection)
            {
                stack.Push(obj);
            }
        }

        public static void Run(this IndexStack<object> stack, ICommand cmd)
        {
            cmd.Run(stack);
        }
    }
}