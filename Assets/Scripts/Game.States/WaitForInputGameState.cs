using JetBrains.Annotations;
using MIG.API;

namespace MIG.Game.States
{
    [UsedImplicitly]
    public sealed class WaitForInputGameState :
        AbstractGameState,
        IWaitForInputState,
        IExitableState
    {
        private readonly ILogService _logger;
        private readonly IInputHandler _inputHandler;
        private readonly IProjectileShooter _projectileShooter;

        public WaitForInputGameState(
            ILogService logger,
            IInputHandler inputHandler,
            IProjectileShooter projectileShooter
        )
        {
            _logger = logger;
            _inputHandler = inputHandler;
            _projectileShooter = projectileShooter;
        }

        public void Enter()
        {
            _logger.Log(LogChannel, "Waiting for user input");
            _projectileShooter.Prepare();
            _inputHandler.OnAimingStart += OnAimingStart;
        }

        public void Exit()
        {
            _logger.Log(LogChannel, "User input received");
            _inputHandler.OnAimingStart -= OnAimingStart;
        }

        private void OnAimingStart()
            => GameStateService.Aim();
    }
}