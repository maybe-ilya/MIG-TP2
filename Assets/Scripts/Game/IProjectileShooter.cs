using UnityEngine;

namespace MIG.Game
{
    public interface IProjectileShooter
    {
        Vector3 ShootPoint { get; }
        Vector3 ForceVector { get; }
        float ProjectileMass { get; }

        void Prepare();
        void LookAt(Vector3 position);
        void Shoot();
        void ResetOrientation();
    }
}
