using JetBrains.Annotations;
using MIG.API;

namespace MIG.Game.States
{
    [UsedImplicitly]
    public sealed class ShootGameState : AbstractGameState, IShootGameState
    {
        private readonly ILogService _logger;
        private readonly IProjectileShooter _projectileShooter;

        public ShootGameState(
            ILogService logger,
            IProjectileShooter projectileShooter
        )
        {
            _logger = logger;
            _projectileShooter = projectileShooter;
        }

        public void Enter()
        {
            _logger.Log(LogChannel, "Shooting");
            _projectileShooter.Shoot();
            GameStateService.WaitForInput();
        }
    }
}