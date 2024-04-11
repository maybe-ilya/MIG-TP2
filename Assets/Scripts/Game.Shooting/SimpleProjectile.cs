using System;
using System.Collections;
using JetBrains.Annotations;
using MIG.API;
using UnityEngine;

namespace MIG.Game.Shooting
{
    [UsedImplicitly]
    public sealed class SimpleProjectile : MonoBehaviour, IProjectile
    {
        [SerializeField]
        [CheckObject]
        private Rigidbody _rigidbody;

        [SerializeField]
        private float _selfDestroyDelay;
        
        private bool _isLaunched;

        public float Mass => _rigidbody.mass;

        public event Action OnDestroy;

        public void Init()
        {
            _rigidbody.constraints |= RigidbodyConstraints.FreezePosition;
            _rigidbody.useGravity = false;
            _isLaunched = false;
        }

        public void Launch(Vector3 forceVector)
        {
            _rigidbody.constraints &= ~RigidbodyConstraints.FreezePosition;
            _rigidbody.useGravity = true;
            _rigidbody.AddForce(forceVector, ForceMode.Impulse);
            _isLaunched = true;
            StartCoroutine(WaitToSelfDestroy());
        }
        
        private void OnCollisionEnter(Collision other)
        {
            if (!_isLaunched)
            {
                return;
            }
            
            SelfDestroy();
        }

        private IEnumerator WaitToSelfDestroy()
        {
            yield return new WaitForSeconds(_selfDestroyDelay);
            SelfDestroy();
        }

        private void SelfDestroy()
        {
            OnDestroy?.Invoke();
            Destroy(gameObject);
        }
    }
}