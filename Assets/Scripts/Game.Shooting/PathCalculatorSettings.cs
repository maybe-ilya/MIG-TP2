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

        [SerializeField]
        private PathDeltaTimeType _deltaTimeType;

        [SerializeField]
        private float _constDeltaTime;
        
        public int PathSegments => _pathSegments;

        public LayerMask CollisionMask => _collisionMask;

        public PathDeltaTimeType DeltaTimeType => _deltaTimeType;

        public float ConstDeltaTime => _constDeltaTime;
    }
}
