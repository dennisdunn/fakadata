namespace Models
{
    public interface IDecorator<T>
    {
        T Target { get; }
    }
}
