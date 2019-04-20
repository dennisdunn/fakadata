using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleStackMachine
{
    public static class Extensions
    {
        public static T Pop<T>(this IStackList<object> stack)
        {
            var item = stack.Pop();
            if (typeof(T).IsAssignableFrom(item.GetType()))
                return (T)item;
            else
                return (T)Convert.ChangeType(item, typeof(T));
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
            var text = stack.Select(item => item.ToString());
            return text.ToArray();
        }

        public static bool HasA<T>(this IStackList<object> stack, int idx)
        {

            return typeof(T).IsAssignableFrom(stack[idx].GetType());
        }

        public static bool HasA<T1>(this IStackList<object> stack)
        {
            return stack.HasA<T1>(0);
        }

        public static bool HasA<T1, T2>(this IStackList<object> stack)
        {
            return stack.HasA<T1>(0) && stack.HasA<T2>(1);
        }
    }
}