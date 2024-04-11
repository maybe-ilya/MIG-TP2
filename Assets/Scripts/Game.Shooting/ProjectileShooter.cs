using JetBrains.Annotations;
using MIG.API;
using UnityEngine;

namespace MIG.Game.Shooting
{
    [UsedImplicitly]
    public sealed class ProjectileShooter : MonoBehaviour, IProjectileShooter
    {
        [SerializeField]
        [CheckObject]
        private Transform _shootTransform;

        [SerializeField]
        private float _forceAmount;
        
        private IProjectileFactory _projectileFactory;
        private IProjectile _projectile;
        
        public Vector3 ShootPoint => _shootTransform.position;
        public Vector3 ForceVector { get; private set; }
        public float ProjectileMass => _projectile.Mass;

        public void Init(IProjectileFactory projectileFactory)
        {
            _projectileFactory = projectileFactory;
        }
        
        public void Prepare()
        {
            _projectile = _projectileFactory.Create(ShootPoint);
        }

        public void LookAt(Vector3 position)
        {
            ForceVector = (position - ShootPoint).normalized * _forceAmount;
        }

        public void Shoot()
        {
            _projectile.Launch(ForceVector);
            _projectile = null;
        }

        public void ResetOrientation()
        {
            ForceVector = Vector3.zero;
        }
    }
}