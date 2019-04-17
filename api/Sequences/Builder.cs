using SimpleStackMachine;
using System.Collections.Generic;

namespace Sequences
{
    public class Builder
    {
        protected StackMachine _stackMachine = new StackMachine();

        public IEnumerable<double> Build()
        {
            return (IEnumerable<double>)_stackMachine.Context.Pop();
        }

        public Builder Eval(params string[] text)
        {
            _stackMachine.Eval(text);

            return this;
        }

        public Builder Load(string key)
        {
            _stackMachine.Eval(key, Magic.COMMAND_LOAD);

            return this;
        }

        public Builder Merge()
        {
            _stackMachine.Eval(Magic.COMMAND_COMBINE);

            return this;
        }

        public Builder Concat()
        {
            _stackMachine.Eval(Magic.COMMAND_CONCAT);

            return this;
        }

        public Builder Map(string expr)
        {
            _stackMachine.Eval(expr, Magic.COMMAND_MAP);

            return this;
        }

        public Builder Limit(int limit)
        {
            _stackMachine.Eval(limit.ToString(), Magic.COMMAND_MAP);

            return this;
        }

        public Builder Noise()
        {
            _stackMachine.Eval(Magic.COMMAND_NOISE);

            return this;
        }

        public Builder Cardinals()
        {
            _stackMachine.Eval(Magic.COMMAND_CARDINALS);

            return this;
        }
    }
}
