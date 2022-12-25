using UnityEngine;

namespace Chapter.Visitor
{
    public class BikeShield : MonoBehaviour, IBikeElement
    {
        public float Health = 50.0f;
        public float Damage(float damage)
        {
            Health -= damage;
            return Health;
        }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
        private void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(new Rect(125, 0, 200, 20), "Shield Health: " + Health);
        }
    }
}
