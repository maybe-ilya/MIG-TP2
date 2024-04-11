using MIG.API;
using MIG.Game;
using MIG.Game.Shooting;
using MIG.Game.States;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MIG.Main
{
    public sealed class GameRegistrator : AbstractRegistrator
    {
        [SerializeField]
        [CheckObject]
        private SimpleProjectile _projectilePrefab;

        [SerializeField]
        [CheckObject]
        private ProjectileShooter _projectileShooter;

        [SerializeField]
        [CheckObject]
        private PathVisualizer _pathVisualizerPrefab;
        
        public override void Register(IContainerBuilder builder)
        {
            RegisterStates(builder);
            RegisterShootingDependencies(builder);
        }

        private void RegisterStates(IContainerBuilder builder)
        {
            builder.Register<WaitForInputGameState>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<AimGameState>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<ShootGameState>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<GameStateService>(Lifetime.Scoped).AsImplementedInterfaces();

            builder.RegisterBuildCallback(OnContainerBuild);
        }

        private void RegisterShootingDependencies(IContainerBuilder builder)
        {
            builder.RegisterInstance(_projectileShooter).AsImplementedInterfaces().AsSelf();
            builder.RegisterInstance(_projectilePrefab).AsSelf();
            builder.Register<SimpleProjectileFactory>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<PathCalculator>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.RegisterComponentOnNewGameObject<InputHandler>(Lifetime.Scoped, "[INPUT]")
                .AsImplementedInterfaces();
            builder.RegisterComponentInNewPrefab(_pathVisualizerPrefab, Lifetime.Scoped).AsImplementedInterfaces();
        }
        
        private void OnContainerBuild(IObjectResolver resolver)
        {
            resolver.Resolve<ProjectileShooter>().Init(resolver.Resolve<IProjectileFactory>());
            
            resolver.Resolve<IGameStateService>().WaitForInput();
        }
    }
}