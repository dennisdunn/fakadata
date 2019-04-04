using Models;

namespace Engine
{
    public class ValueGenerator : BaseGenerator<double>, ITsDescriptionDecorator
    {
        private int _idx = 0;

        public ValueGenerator(ITsDescription target) : base(target)
        {
        }

        public override bool MoveNext()
        {

            Current = _idx++;
            return true;
        }

        public override void Reset()
        {
            _idx = 0;
        }
    }
}
