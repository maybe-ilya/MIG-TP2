using UnityEngine;

namespace MIG.Game
{
    public interface IPathCalculator
    {
        Vector3[] CalculatePath(PathCalculationParams @params);
    }
}