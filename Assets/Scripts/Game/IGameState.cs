using MIG.API;

namespace MIG.Game
{
    public interface IGameState : IState
    {
        void SetGameStateService(IGameStateService gameStateService);
    }
}