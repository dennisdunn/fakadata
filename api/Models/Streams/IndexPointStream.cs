using System.Collections.Generic;

namespace Models.Streams
{
    public class IndexPointStream : BasePointStream
    {
        private int _idx;

        public IndexPointStream() : base("Index") { }

        public override IEnumerator<IDatapoint> GetEnumerator()
        {
            return Source().GetEnumerator();
        }

        private IEnumerable<IDatapoint> Source()
        {
            yield return new Datapoint { Value = _idx++ };
        }
    }
}
