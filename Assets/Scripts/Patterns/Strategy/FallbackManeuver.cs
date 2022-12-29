using System.Collections;
using UnityEngine;
namespace Chapter.Strategy
{
    public class FallbackManeuver : MonoBehaviour, IManeuverBehavior
    {
        public void Maneuver(Drone drone)
        {
            StartCoroutine(Fallback(drone));
        }

        IEnumerator Fallback(Drone drone)
        {
            float time = 0;
            float speed = drone.Speed;
            Vector3 startPosition = drone.transform.position;
            Vector3 endPosition = startPosition;
            endPosition.z = drone.FallbackDistance;
            while (time < speed)
            {
                drone.transform.position = Vector3.Lerp(startPosition, endPosition, time / speed);
                time += Time.deltaTime;
                yield return null;
            }
        }
    }
}
