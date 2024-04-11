using JetBrains.Annotations;
using UnityEngine;
using UObject = UnityEngine.Object;

namespace MIG.Game.Shooting
{
    [UsedImplicitly]
    public sealed class SimpleProjectileFactory : IProjectileFactory
    {
        private readonly SimpleProjectile _simpleProjectilePrefab;

        public SimpleProjectileFactory(SimpleProjectile simpleProjectilePrefab)
        {
            _simpleProjectilePrefab = simpleProjectilePrefab;
        }

        public IProjectile Create(Vector3 input)
        {
            var result = UObject.Instantiate(_simpleProjectilePrefab, input, Quaternion.identity);
            result.Init();
            return result;
        }
    }
}