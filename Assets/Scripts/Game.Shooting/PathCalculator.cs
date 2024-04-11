using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace MIG.Game.Shooting
{
    [UsedImplicitly]
    public sealed class PathCalculator : IPathCalculator
    {
        private readonly PathCalculatorSettings _settings;

        public PathCalculator(PathCalculatorSettings settings)
        {
            _settings = settings;
        }

        private static Vector3 Gravity => Physics.gravity;
        
        public Vector3[] CalculatePath(PathCalculationParams @params)
        {
            var result = new List<Vector3> { @params.origin };

            var velocity = (@params.force / @params.mass) * Time.fixedDeltaTime;
            var duration = (2 * velocity.y) / Gravity.y;
            var timeStep = duration / _settings.PathSegments;

            for (var i = 1; i < _settings.PathSegments; ++i)
            {
                var timeOffset = timeStep * i;
                var moveOffset = velocity * timeOffset;
                moveOffset.y -= 0.5f * Gravity.y * timeOffset * timeOffset;

                var checkPoint = @params.origin - moveOffset;
                if (Physics.Linecast(@params.origin, checkPoint, out var hit, _settings.CollisionMask))
                {
                    result.Add(hit.point);
                    break;
                }
                else
                {
                    result.Add(checkPoint);
                }
            }
            
            return result.ToArray();
        }
    }
}
