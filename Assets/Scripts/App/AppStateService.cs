using JetBrains.Annotations;
using MIG.API;
using MIG.StateMachine;

namespace MIG.AppState
{
    [UsedImplicitly]
    public sealed class AppStateService : IAppStateService
    {
        private readonly IStateMachine _stateMachine;

        public AppStateService(
            IMainMenuState mainMenuState,
            IGameplayAppState gameplayAppState,
            IQuitAppState quitAppState
        )
        {
            var stateMachine = new SimpleStateMachine();
            stateMachine.Add(mainMenuState);
            stateMachine.Add(gameplayAppState);
            stateMachine.Add(quitAppState);

            mainMenuState.SetStateService(this);
            gameplayAppState.SetStateService(this);
            quitAppState.SetStateService(this);

            _stateMachine = stateMachine;
        }

        public void GoToMainMenu()
            => _stateMachine.ChangeState<IMainMenuState>();

        public void PlayGame()
            => _stateMachine.ChangeState<IGameplayAppState>();

        public void QuitGame()
            => _stateMachine.ChangeState<IQuitAppState>();
    }
}