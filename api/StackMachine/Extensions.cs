using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleStackMachine
{
    public static class Extensions
    {
        public static T PopAs<T>(this IStackList<object> stack)
        {
            var obj = stack.Pop();
            T result;
            try
            {
                result = (T)Convert.ChangeType(obj, typeof(T));
            }
            catch
            {
                result = default;
            }
            return result;
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