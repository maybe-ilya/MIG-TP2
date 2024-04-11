using JetBrains.Annotations;
using MIG.API;
using UnityEngine;

namespace MIG.Game.States
{
    [UsedImplicitly]
    public sealed class AimGameState :
        AbstractGameState,
        IAimGameState,
        IExitableState
    {
        private readonly ILogService _logger;
        private readonly IInputHandler _inputHandler;
        private readonly IProjectileShooter _projectileShooter;
        private readonly IPathCalculator _pathCalculator;
        private readonly IPathVisualiazer _pathVisualiazer;

        public AimGameState(
            ILogService logger,
            IInputHandler inputHandler,
            IProjectileShooter projectileShooter,
            IPathCalculator pathCalculator,
            IPathVisualiazer pathVisualiazer
        )
        {
            _logger = logger;
            _inputHandler = inputHandler;
            _projectileShooter = projectileShooter;
            _pathCalculator = pathCalculator;
            _pathVisualiazer = pathVisualiazer;
        }

        public void Enter()
        {
            _logger.Log(LogChannel, "Aiming Started");
            _inputHandler.OnAiming += OnAiming;
            _inputHandler.OnAimingFinish += OnAimingFinish;
            _pathVisualiazer.Show();
        }

        public void Exit()
        {
            _logger.Log(LogChannel, "Aiming Finished");
            _pathVisualiazer.Hide();
            _inputHandler.OnAiming -= OnAiming;
            _inputHandler.OnAimingFinish -= OnAimingFinish;
        }

        private void OnAimingFinish()
            => GameStateService.Shoot();

        private void OnAiming(Vector3 point)
        {
            _projectileShooter.LookAt(point);
            var @params = new PathCalculationParams()
            {
                origin = _projectileShooter.ShootPoint,
                force = _projectileShooter.ForceVector,
                mass = _projectileShooter.ProjectileMass,
                pathSegments = 50
            };
            _pathVisualiazer.Visualize(_pathCalculator.CalculatePath(@params));
        }
    }
}