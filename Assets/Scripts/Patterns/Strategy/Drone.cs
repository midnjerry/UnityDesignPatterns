using UnityEngine;
namespace Chapter.Strategy
{
    public class Drone : MonoBehaviour
    {
        private RaycastHit _hit;
        private Vector3 _rayDirection;
        private float _rayAngle = -45.0f;
        private float _rayDistance = 15.0f;

        public float Speed = 1.0f;
        public float MaxHeight = 5.0f;
        public float WeavingDistance = 1.5f;
        public float FallbackDistance = 20.0f;
        private void Start()
        {
            _rayDirection = transform.TransformDirection(Vector3.back) * _rayDistance;
            _rayDirection = Quaternion.Euler(_rayAngle, 0, 0) * _rayDirection;
        }
        public void ApplyStrategy(IManeuverBehavior strategy)
        {
            strategy.Maneuver(this);
        }
        private void Update()
        {
            Debug.DrawRay(transform.position, _rayDirection, Color.blue);
            if (Physics.Raycast(transform.position, _rayDirection, out _hit, _rayDistance))
            {
                if (_hit.collider)
                {
                    Debug.DrawRay(transform.position, _rayDirection, Color.green);
                }
            }
        }
    }
}