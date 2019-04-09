using Flee.PublicTypes;
using System;
using Timeseries.Api.Models;

namespace Timeseries.Api.Evaluator
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
            _context.Imports.AddType(typeof(Probability));
            _context.Variables["x"] = _idx;
            _expression = _context.CompileGeneric<double>(string.Join('+', Target.Expressions));
        }

        public override bool MoveNext()
        {
            _context.Variables["x"] = _idx++;
            Current = _expression.Evaluate();

            return true;
        }
    }
}
