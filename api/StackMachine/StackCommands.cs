namespace SimpleStackMachine
{
    public class Swap : ICommand
    {
        public void Run(IndexStack<object> stack)
        {
            var obj = stack.Pop();
            stack.Insert(1,obj);
        }
    }
    public class Drop : ICommand
    {
        public void Run(IndexStack<object> stack)
        {
            stack.Pop();
        }
    }

    public class Pick : ICommand
    {
        public void Run(IndexStack<object> stack)
        {
            var i = stack.Pop<int>();
            var obj = stack[i];
            stack.Remove(obj);
            stack.Push(obj);
        }
    }

    public class Roll : ICommand
    {
        public void Run(IndexStack<object> stack)
        {
            var i = stack.Pop<int>();
            for(var j = 0; j < i; j++)
            {
                var obj = stack.Pop();
                stack.Add(obj);
            }
        }
    }
}
