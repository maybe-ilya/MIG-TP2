using MIG.Logging;
using MIG.SceneLoading;
using VContainer;

namespace MIG.Main
{
    public sealed class MandatoryServicesRegistrator : AbstractRegistrator
    {
        public override void Register(IContainerBuilder builder)
        {
            builder.Register<UnityLogService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<SceneLoadService>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
