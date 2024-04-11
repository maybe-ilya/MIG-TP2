using UnityEngine;

namespace MIG.Game.Shooting
{
    [CreateAssetMenu]
    public sealed class PathCalculatorSettings : ScriptableObject
    {
        [SerializeField]
        private int _pathSegments;

        [SerializeField]
        private LayerMask _collisionMask;

        public int PathSegments => _pathSegments;

        public LayerMask CollisionMask => _collisionMask;
    }
}
