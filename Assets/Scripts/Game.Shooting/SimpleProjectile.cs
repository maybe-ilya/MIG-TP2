using System;
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
        private float _invulnerabilityTimeAfterLaunch;

        private bool _isLaunched;
        private float _remainingInvulnerabilityTime;
        private bool _isAbleToCollide;

        public float Mass => _rigidbody.mass;

        public event Action OnHit;

        public void Init()
        {
            _rigidbody.detectCollisions = false;
            _rigidbody.isKinematic = true;
            _rigidbody.useGravity = false;

            _isLaunched = false;
            _isAbleToCollide = false;
            _remainingInvulnerabilityTime = 0;
        }

        public void Launch(Vector3 forceVector)
        {
            _rigidbody.detectCollisions = true;
            _rigidbody.isKinematic = false;
            _rigidbody.useGravity = true;
            _rigidbody.AddForce(forceVector, ForceMode.Impulse);

            _isLaunched = true;
            _remainingInvulnerabilityTime = _invulnerabilityTimeAfterLaunch;
        }

        private void Update()
        {
            if (!_isLaunched || _isAbleToCollide)
            {
                return;
            }

            _remainingInvulnerabilityTime = Math.Max(0.0f, _remainingInvulnerabilityTime - Time.deltaTime);
            if (_remainingInvulnerabilityTime < float.Epsilon)
            {
                _isAbleToCollide = true;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!_isAbleToCollide)
            {
                return;
            }

            OnHit?.Invoke();
            Destroy(gameObject);
        }
    }
}