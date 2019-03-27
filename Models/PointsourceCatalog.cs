using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Models
{
    public partial class Pointsource
    {
        public static IEnumerable<string> Catalog { get; private set; }

        static Pointsource()
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(EMBEDDED_RESOURCE))
            using (var reader = new StreamReader(stream))
            {
                var row = reader.ReadLine();
                Catalog = row.Split(',').Skip(1);
            }
        }
    }
}
