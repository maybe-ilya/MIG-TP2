using MIG.API;
using UnityEngine;

namespace MIG.Main
{
    public class TrajectoryHandler : MonoBehaviour
    {
        [SerializeField]
        [CheckObject]
        private TrajectoryInputListener _inputListener;

        [SerializeField]
        [CheckObject]
        private TrajectoryCalculator _trajectoryCalculator;

        [SerializeField]
        [CheckObject]
        private TrajectoryVisualizer _trajectoryVisualizer;

        [SerializeField]
        [CheckObject]
        private ProjectileLauncher _projectileLauncher;
        
        private void Start()
        {
            _inputListener.OnStartAiming += OnStartAiming;
            _inputListener.OnFinishAiming += OnFinishAiming;
            _inputListener.OnAiming += OnAiming;
        }
        
        private void OnStartAiming()
        {
            _trajectoryVisualizer.Show();
        }

        private void OnFinishAiming()
        {
            // _trajectoryVisualizer.Hide();
            _projectileLauncher.Launch();
        }

        private void OnAiming(Vector3 point)
        {
            _projectileLauncher.LookAt(point);
            var path = _trajectoryCalculator.CalculateTrajectory(_projectileLauncher.Position, _projectileLauncher.Velocity,
                Time.deltaTime);
            _trajectoryVisualizer.SetTrajectory(path);
        }
    }
}