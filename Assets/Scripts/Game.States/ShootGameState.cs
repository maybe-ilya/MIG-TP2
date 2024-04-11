using System;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using MIG.API;

namespace MIG.Game.States
{
    [UsedImplicitly]
    public sealed class ShootGameState : AbstractGameState, IShootGameState
    {
        private readonly ILogService _logger;
        private readonly IProjectileShooter _projectileShooter;
        private readonly IPathVisualiazer _pathVisualiazer;

        private const float FIRE_RATE = 3.0f;

        public ShootGameState(
            ILogService logger,
            IProjectileShooter projectileShooter, 
            IPathVisualiazer pathVisualiazer
            )
        {
            _logger = logger;
            _projectileShooter = projectileShooter;
            _pathVisualiazer = pathVisualiazer;
        }

        public void Enter()
        {
            _logger.Log(LogChannel, "Shooting");
            _projectileShooter.Shoot();
            ShootingDelay().Forget();
        }

        private async UniTaskVoid ShootingDelay()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(FIRE_RATE));
            _pathVisualiazer.Hide();
            GameStateService.WaitForInput();
        }
    }
}