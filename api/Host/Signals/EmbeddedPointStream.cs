using Models.Streams;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Timeseries.Api.Signals
{
    public class EmbeddedPointStream : BasePointStream, IDisposable
    {
        private readonly Stream _stream;
        private readonly System.Collections.Generic.IEnumerable<IDatapoint> _reader;

        public EmbeddedPointStream(string name) : base(name)
        {
            var assembly = Assembly.GetExecutingAssembly();

            _stream = assembly.GetManifestResourceStream(Catalog.EMBEDDED_RESOURCE);
            _reader = Csv.CsvReader.ReadFromStream(_stream).Select(row => new Datapoint { Value = Convert.ToDouble(row[name]) });
        }

        public override IEnumerator<IDatapoint> GetEnumerator()
        {
            return _reader.GetEnumerator();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _stream.Dispose();
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CatalogStream() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
