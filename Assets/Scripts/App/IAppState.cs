using MIG.API;

namespace MIG.AppState
{
    public interface IAppState : IState
    {
        void SetStateService(IAppStateService appStateService);
    }
}