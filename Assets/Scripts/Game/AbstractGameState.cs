using MIG.API;

namespace MIG.Game
{
    public abstract class AbstractGameState : IGameState
    {
        protected IGameStateService GameStateService { get; private set; }
        protected LogChannel LogChannel = "[GAME]";
        
        public void SetGameStateService(IGameStateService gameStateService)
        {
            GameStateService = gameStateService;
        }
    }
}
