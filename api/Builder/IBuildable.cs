using Models;

namespace Builder
{
    public interface IBuildable
    {
        IPointStream Build();
        IPointStream Build(bool isPerpetual);
    }
}
