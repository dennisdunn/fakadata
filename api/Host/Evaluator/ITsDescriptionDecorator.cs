using Timeseries.Api.Models;

namespace Timeseries.Api.Evaluator
{
    public interface ITsDescriptionDecorator
    {
       ITsDescription Target { get; }
    }
}