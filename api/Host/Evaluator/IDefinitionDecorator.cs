using Timeseries.Api.Models;

namespace Timeseries.Api.Evaluator
{
    public interface IDefinitionDecorator
    {
       IDefinition Target { get; }
    }
}