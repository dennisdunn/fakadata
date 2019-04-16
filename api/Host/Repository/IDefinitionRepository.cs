using System.Collections.Generic;
using Timeseries.Api.Models;

namespace Timeseries.Api.Repository
{
    public interface IDefinitionRepository
    {
        IEnumerable<object> List();
        IDefinition Create(Definition item);
        IDefinition Read(int id);
        IDefinition Read(string name);
        void Update(Definition item);
        void Delete(int id);
        void Delete(IDefinition item);
    }
}