using MIG.API;
using UnityEngine;

namespace MIG.Main
{
    public class TrajectoryVisualizer : MonoBehaviour
    {
        [SerializeField]
        [CheckObject]
        private LineRenderer _lineRenderer;

        public void SetTrajectory(Vector3[] trajectory)
        {
            _lineRenderer.positionCount = trajectory.Length;
            _lineRenderer.SetPositions(trajectory);
        }

        public void Show()
            => SetLineRendererActive(true);

        public void Hide()
            => SetLineRendererActive(false);

        private void SetLineRendererActive(bool newActive)
            => _lineRenderer.gameObject.SetActive(newActive);
    }
}