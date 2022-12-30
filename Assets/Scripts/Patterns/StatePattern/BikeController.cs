using UnityEngine;

namespace Chapter.State
{
    public class BikeController : MonoBehaviour
    {
        public float maxSpeed = 2.0f;
        public float turnDistance = 2.0f;
        public float CurrentSpeed { get; set; }
        public Direction CurrentTurnDirection { get; private set; }
        private IBikeState _startState, _stopState, _turnState;
        private string _status;
        private bool _isTurboOn;

        private BikeStateContext _bikeStateContext;
        private void Start()
        {
            _bikeStateContext = new BikeStateContext(this);
            _startState = gameObject.AddComponent<BikeStartState>();
            _stopState = gameObject.AddComponent<BikeStopState>();
            _turnState = gameObject.AddComponent<BikeTurnState>();
            _bikeStateContext.Transition(_stopState);
        }

        public void ToggleTurbo()
        {
            _isTurboOn = !_isTurboOn;
            Debug.Log("Turbo Active: " + _isTurboOn.ToString());
        }

        public void StartBike()
        {
            _status = "Started";
            _bikeStateContext.Transition(_startState);
        }

        public void StopBike()
        {
            _status = "Stopped";
            _bikeStateContext.Transition(_stopState);
        }

        public void Turn(Direction direction)
        {
            CurrentTurnDirection = direction;
            _bikeStateContext.Transition(_turnState);
        }

        public void ResetPosition()
        {
            transform.position = new Vector3(2, 1.0f, -25f);
        }
        
        private void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(
                new Rect(10, 260, 200, 20),
                "BIKE STATUS: " + _status);


        }
    }
}