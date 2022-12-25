using UnityEngine;

namespace Chapter.Visitor {
    public class BikeWeapon : MonoBehaviour, IBikeElement
    {
        [Header("Range")]
        public int Range = 5;
        public readonly int MaxRange = 25;
        [Header("Strength")]
        public float Strength = 25.0f;
        public readonly float MaxStrength = 50.0f;

        public void Fire()
        {
            Debug.Log("Weapon Fired with " + Strength + " damage and range of " + Range);
        }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        private void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(
                new Rect(125, 40, 200, 20), "Weapon Range: " + Range);
            GUI.Label(new Rect(125, 60, 200, 20), "Weapon Strength: " + Strength);
        }
    }
}
