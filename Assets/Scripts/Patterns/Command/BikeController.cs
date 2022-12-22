using UnityEngine;
namespace Chapter.Command
{
    public class BikeController : MonoBehaviour
    {
        public enum Direction
        {
            LEFT = -1,
            RIGHT = 1
        }

        private bool _isTurboOn;
        private float _distance = 1.0f;

        public void ToggleTurbo()
        {
            _isTurboOn = !_isTurboOn;
            Debug.Log("Turbo Active: " + _isTurboOn.ToString());
        }

        public void Turn(Direction direction)
        {
            if (direction == Direction.LEFT)
            {
                transform.Translate(Vector3.left * _distance);
            } else if (direction == Direction.RIGHT)
            {
                transform.Translate(Vector3.right * _distance);
            }
            
        }
        public void ResetPosition()
        {
            transform.position = new Vector3(2, 1.0f, -25f);
        }               
    }
}