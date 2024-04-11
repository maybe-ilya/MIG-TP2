using JetBrains.Annotations;
using UnityEngine;

namespace MIG.Game.Shooting
{
    [UsedImplicitly]
    public sealed class PathCalculator : IPathCalculator
    {
        public Vector3[] CalculatePath(PathCalculationParams @params)
        {
            return new Vector3[2];  // TODO: сделать вычисления
        }
    }
}
