using MIG.API;
using MIG.AppState;

namespace MIG.App
{
    public abstract class AbstractAppState : IAppState
    {
        protected IAppStateService AppStateService { get; private set; }
        protected LogChannel StateLogChannel = "[APP]";

        public void SetStateService(IAppStateService appStateService)
        {
            AppStateService = appStateService;
        }
    }
}
