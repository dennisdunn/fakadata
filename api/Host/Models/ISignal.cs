namespace Timeseries.Api.Models
{
    public interface ISignal : IDocument
    {
        string Expression { get; set; }
    }
}
