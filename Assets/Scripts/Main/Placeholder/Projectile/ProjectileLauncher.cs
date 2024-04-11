using UnityEngine;

namespace MIG.Main
{
    public class ProjectileLauncher : MonoBehaviour
    {
        [SerializeField]
        private float _force;
        
        public Vector3 Position => gameObject.transform.position;

        public Vector3 Velocity => gameObject.transform.forward * _force;

        public void LookAt(Vector3 point)
        {
            // transform.forward = (point - transform.position).normalized;
            transform.LookAt(point);
        }

        public void ResetOrientation()
        {
            transform.localRotation = Quaternion.identity;
        }

        public void Launch()
        {
            // TODO:
        }
    }
}