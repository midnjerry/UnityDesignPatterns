using UnityEngine;
namespace Chapter.Visitor
{
    public class BikeEngine : MonoBehaviour, IBikeElement
    {
        public float TurboBoost = 25.0f;
        public readonly float MaxTurboBoost = 200.0f;

        private bool _isTurboOn;
        private float _defaultSpeed = 300.0f;

        public float CurrentSpeed
        {
            get
            {
                if (_isTurboOn)
                {
                    return _defaultSpeed + TurboBoost;
                }
                return _defaultSpeed;
            }
        }

        public void ToggleTurbo()
        {
            _isTurboOn = !_isTurboOn;
        }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
        private void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(new Rect(125, 20, 200, 20), "Turbo Boost: " + TurboBoost);
        }
    }
}
