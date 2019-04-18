namespace SimpleStackMachine
{
    public static class StackCommands
    {
        public static void Swap(IStackList<object> stack)
        {
            var obj = stack.Pop();
            stack.Insert(1, obj);
        }

        public static void Drop(IStackList<object> stack)
        {
            stack.Pop();
        }

        public static void Pick(IStackList<object> stack)
        {
            var i = stack.PopAs<int>();
            var obj = stack[i];
            stack.Remove(obj);
            stack.Push(obj);
        }

        public static void Roll(IStackList<object> stack)
        {
            var i = stack.PopAs<int>();
            for (var j = 0; j < i; j++)
            {
                var obj = stack.Pop();
                stack.Add(obj);
            }
        }

        public static void Clear(IStackList<object> stack)
        {
            stack.Clear();
        }
    }
}
