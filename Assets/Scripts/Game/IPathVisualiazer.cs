using UnityEngine;

namespace MIG.Game
{
    public interface IPathVisualiazer
    {
        void Show();
        void Hide();
        void Visualize(Vector3[] path);
    }
}