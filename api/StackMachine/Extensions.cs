using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleStackMachine
{
    public static class Extensions
    {
        public static T PopAs<T>(this IStackList<object> stack)
        {
            var obj = stack.Pop();
            var result = Convert.ChangeType(obj, typeof(T));
            return (T)result;
        }

        public static void PushRange<T>(this IStackList<object> stack, IEnumerable<T> collection)
        {
            foreach (var obj in collection)
            {
                stack.Push(obj);
            }
        }

        public static string[] ToDisplay(this IStackList<object> stack)
        {
            var text = stack.Select(item=>item.ToString());
            return text.ToArray();
        }
    }
}