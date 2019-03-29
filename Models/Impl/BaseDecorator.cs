namespace Models.Impl
{
    public class BaseDecorator<T> : IDecorator<T>
    {
        public T Target { get; protected set; }

        public BaseDecorator() { }

        public BaseDecorator(T target)
        {
            Target = target;
        }
    }
}
