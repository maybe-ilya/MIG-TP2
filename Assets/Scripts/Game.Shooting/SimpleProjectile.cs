using JetBrains.Annotations;
using MIG.API;
using UnityEngine;

namespace MIG.Game.Shooting
{
    [UsedImplicitly]
    public class SimpleProjectile : MonoBehaviour, IProjectile
    {
        [SerializeField]
        [CheckObject]
        private Rigidbody _rigidbody;

        public float Mass => _rigidbody.mass;

        public void Init()
        {
            _rigidbody.detectCollisions = false;
            _rigidbody.isKinematic = true;
            _rigidbody.useGravity = false;
        }
        
        public void Launch(Vector3 forceVector)
        {
            _rigidbody.detectCollisions = true;
            _rigidbody.isKinematic = false;
            _rigidbody.useGravity = true;
            _rigidbody.AddForce(forceVector, ForceMode.Impulse);
        }
    }
}
