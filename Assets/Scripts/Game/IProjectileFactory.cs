using MIG.API;
using UnityEngine;

namespace MIG.Game
{
    public interface IProjectileFactory : IFactory<IProjectile, Vector3>
    {
    }
}