using VContainer;

namespace MIG.Main
{
    public class AppLifetimeScope : AbstractLifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            DontDestroyOnLoad(gameObject);
            base.Configure(builder);
        }
    }
}