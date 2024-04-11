using System.Collections.Generic;
using UnityEngine;

namespace MIG.Main
{
    public class TrajectoryCalculator : MonoBehaviour
    {
        [SerializeField]
        private int _maxPoints;

        [SerializeField]
        private LayerMask _collisionMask;

        public Vector3[] CalculateTrajectory(Vector3 startPosition, Vector3 startVelocity, float timeStep)
        {
            var result = new List<Vector3> { startPosition };

            for (var i = 1; i < _maxPoints; ++i)
            {
                var timeOffset = timeStep * i;
                var nextPoint = startPosition
                            + timeOffset * startVelocity
                            + 0.5f * Physics.gravity * timeOffset * timeOffset;

                var prevPoint = result[i - 1];

                if (Physics.Linecast(prevPoint, nextPoint, out var hit, _collisionMask))
                {
                    result.Add(hit.point);
                    break;
                }
                else
                {
                    result.Add(nextPoint);
                }
            }

            return result.ToArray();
        }
    }
}