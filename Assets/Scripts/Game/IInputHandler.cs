using System;
using UnityEngine;

namespace MIG.Game
{
    public interface IInputHandler
    {
        event Action OnAimingStart, OnAimingFinish;
        event Action<Vector3> OnAiming;
    }
}