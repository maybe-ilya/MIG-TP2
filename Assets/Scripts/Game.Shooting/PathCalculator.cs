using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace MIG.Game.Shooting
{
    public enum PathDeltaTimeType
    {
        Const = 0,
        DeltaTime = 1,
        FixedDeltaTime = 2,
    }
    
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
            var origin = @params.origin;
            var force = @params.force;
            var timeStep = GetTimeStep();
            var result = new List<Vector3> { @params.origin };

            for (var i = 1; i < _settings.PathSegments; ++i)
            {
                var timeOffset = timeStep * i;
                var nextPoint = origin
                                + timeOffset * force
                                + 0.5f * Gravity * timeOffset * timeOffset;

                var prevPoint = result[i - 1];

                if (Physics.Linecast(prevPoint, nextPoint, out var hit, _settings.CollisionMask))
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

        private float GetTimeStep()
        {
            return _settings.DeltaTimeType switch
            {
                PathDeltaTimeType.Const => _settings.ConstDeltaTime,
                PathDeltaTimeType.DeltaTime => Time.deltaTime,
                PathDeltaTimeType.FixedDeltaTime => Time.fixedDeltaTime,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
