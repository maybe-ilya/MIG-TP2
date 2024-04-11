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
            => ShootAsync().Forget();
        
        private async UniTaskVoid ShootAsync()
        {
            _logger.Log(LogChannel, "Shooting");
            var projectile = _projectileShooter.Shoot();
            await WaitProjectileToDestroy(projectile);
            _pathVisualiazer.Hide();
            GameStateService.WaitForInput();
        }

        private UniTask WaitProjectileToDestroy(IProjectile projectile)
        {
            var completionSource = new UniTaskCompletionSource();
            projectile.OnDestroy += () => completionSource.TrySetResult();
            return completionSource.Task;
        }
    }
}