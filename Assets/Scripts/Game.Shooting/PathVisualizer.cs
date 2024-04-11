using JetBrains.Annotations;
using MIG.API;
using UnityEngine;

namespace MIG.Game.Shooting
{
    [UsedImplicitly]
    public sealed class PathVisualizer : MonoBehaviour, IPathVisualiazer
    {
        [SerializeField]
        [CheckObject]
        private LineRenderer _lineRenderer;

        [SerializeField]
        [CheckObject]
        private GameObject _marker;

        public void Show()
        {
            SetGameObjectActive(_lineRenderer.gameObject, true);
            SetGameObjectActive(_marker, true);
        }

        public void Hide()
        {
            SetGameObjectActive(_lineRenderer.gameObject, false);
            SetGameObjectActive(_marker, false);
        }

        public void Visualize(Vector3[] path)
        {
            UpdateLineRenderer(path);
            UpdateMarker(path);
        }

        private void SetGameObjectActive(GameObject go, bool isActive)
            => go.SetActive(isActive);

        private void UpdateLineRenderer(Vector3[] path)
        {
            _lineRenderer.positionCount = path.Length;
            _lineRenderer.SetPositions(path);
        }

        private void UpdateMarker(Vector3[] path)
        {
            Vector3 position, upVector = Vector3.up;

            switch (path.Length)
            {
                case 0:
                    position = Vector3.zero;
                    break;

                case 1:
                    position = path[0];
                    break;

                default:
                {
                    var left = path[path.Length - 2];
                    var right = path[path.Length - 1];

                    if (Physics.Linecast(left, right, out var hit))
                    {
                        position = hit.point;
                        upVector = hit.normal;
                    }
                    else
                    {
                        position = right;
                    }
                }
                    break;
            }

            var marketTransform = _marker.transform;
            marketTransform.position = position;
            marketTransform.up = upVector;
        }
    }
}