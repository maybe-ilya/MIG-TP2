using JetBrains.Annotations;
using MIG.API;
using MIG.StateMachine;

namespace MIG.Game
{
    [UsedImplicitly]
    public sealed class GameStateService : IGameStateService
    {
        private readonly IStateMachine _stateMachine;

        public GameStateService(
            IWaitForInputState waitForInputState,
            IAimGameState aimGameState,
            IShootGameState shootGameState
        )
        {
            var stateMachine = new SimpleStateMachine();
            stateMachine.Add(waitForInputState);
            stateMachine.Add(aimGameState);
            stateMachine.Add(shootGameState);
            
            waitForInputState.SetGameStateService(this);
            aimGameState.SetGameStateService(this);
            shootGameState.SetGameStateService(this);
            
            _stateMachine = stateMachine;
        }

        public void WaitForInput()
            => _stateMachine.ChangeState<IWaitForInputState>();

        public void Aim()
            => _stateMachine.ChangeState<IAimGameState>();

        public void Shoot()
            => _stateMachine.ChangeState<IShootGameState>();
    }
}