using SimpleStackMachine;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmbeddedSequences
{
    public static class SequenceFactoryCommands
    {
        public static void Load(IStackList<object> stack)
        {
            if (stack.HasA<string>())
            {
                var name = stack.Pop<string>();
                var seq = SequenceFactory.Load(name);
                stack.Push(seq);
            }
        }
    }
}
