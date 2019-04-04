using Flee.PublicTypes;
using Models;
using System;
using System.Linq;

namespace Engine
{
    public class ValueGenerator : BaseGenerator<double>, ITsDescriptionDecorator
    {
        private readonly ExpressionContext _context;
        private readonly IGenericExpression<double> _expression;
        private int _idx = 0;

        public ValueGenerator(ITsDescription target) : base(target)
        {
            _context = new ExpressionContext();
            _context.Imports.AddType(typeof(Math));
            _context.Variables["x"] = _idx;
            _expression = _context.CompileGeneric<double>(string.Join('+', Target.Source.ToArray()));
        }

        public override bool MoveNext()
        {
            _context.Variables["x"] = _idx++;
            Current = _expression.Evaluate();

            return true;
        }

        public override void Reset()
        {
            _idx = 0;
        }
    }
}
