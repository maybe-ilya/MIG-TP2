using MIG.API;
using UnityEngine;

namespace MIG.Game.Shooting
{
    public sealed class Projectile : MonoBehaviour, IProjectile
    {
        [SerializeField]
        [CheckObject]
        private Rigidbody _rigidbody;

        public float Mass { get; }

        public void Launch(Vector3 forceVector)
        {
            // _rigidbody.mass = mass;
            _rigidbody.AddForce(forceVector, ForceMode.Impulse);
        }
    }
}
