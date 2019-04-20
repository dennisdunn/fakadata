using SimpleStackMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timeseries.Api.Services
{
    public static class RepositoryCommands
    {
        public static void Load(IStackList<object> stack)
        {
            if (stack.HasA<string>())
            {
                var key = stack.Pop<string>();
                var seq = Sequences.SequenceFactory.Load(key);

                stack.Push(seq);
            }
        }

        public static void Save(IStackList<object> stack)
        {
        }

        public static void Delete(IStackList<object> stack)
        {
        }
    }
}
