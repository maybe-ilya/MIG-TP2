using UnityEngine;

namespace MIG.Game
{
    public interface IProjectile
    {
        float Mass { get; }
        void Launch(Vector3 forceVector);
    }
}
