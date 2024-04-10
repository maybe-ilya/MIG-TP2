using MIG.API;
using VContainer;

namespace MIG.Main
{
    public sealed class GameServicesRegistrator : AbstractRegistrator
    {
        public override void Register(IContainerBuilder builder)
        {
            builder.Register<GameServices>(Lifetime.Scoped).AsSelf();
            builder.RegisterBuildCallback(builder => builder.Resolve<GameServices>());
        }
    }
}
