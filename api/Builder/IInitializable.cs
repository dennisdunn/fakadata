using Models;

namespace Builder
{
    public interface IInitializable
    {
        IDecoratable With(IPointStream points);
        IDecoratable With(IBuildable builder);
        IDecoratable With(string name);
    }
}
