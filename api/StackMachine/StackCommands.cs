namespace SimpleStackMachine
{
    public static class StackCommands
    {
        public static void Swap(IStackList<object> stack)
        {
            if (stack.Count > 1)
            {
                var obj = stack.Pop();
                stack.Insert(1, obj);
            }
        }

        public static void Drop(IStackList<object> stack)
        {
            if (stack.Count > 0)
            {
                stack.Pop();
            }
        }

        public static void Pick(IStackList<object> stack)
        {
            if (stack.HasA<int>())
            {
                var i = stack.Pop<int>();
                if (i > stack.Count)
                {
                    var obj = stack[i];
                    stack.Remove(obj);
                    stack.Push(obj);
                }
                else
                {
                    stack.Push(i);
                }
            }
        }

        public static void Roll(IStackList<object> stack)
        {
            if (stack.HasA<int>())
            {
                var i = stack.Pop<int>();
                if (i <= stack.Count)
                {
                    for (var j = 0; j < i; j++)
                    {
                        var obj = stack.Pop();
                        stack.Add(obj);
                    }
                }
                else
                {
                    stack.Push(i);
                }
            }
        }

        public static void Clear(IStackList<object> stack)
        {
            stack.Clear();
        }
    }
}
