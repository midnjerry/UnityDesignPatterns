using UnityEngine;

namespace Chapter.Visitor
{
    [CreateAssetMenu(fileName ="PowerUp", menuName ="PowerUp")]
    public class PowerUp : ScriptableObject, IVisitor
    {
        public string powerupName;
        public GameObject powerupPrefab;
        public string powerupDescription;

        [Tooltip("Fully heal shield")]
        public bool HealShield;

        [Range(0.0f, 50f)]
        [Tooltip("Boost turbo settings up to increments of 50/mph")]
        public int TurboBoost;

        [Range(0.0f, 25f)]
        [Tooltip("Boost weapon range in increments of up to 25 units")]
        public int WeaponRange;

        [Range(0.0f, 50f)]
        [Tooltip("Boost weapon strength in increments of up to 50%")]
        public float WeaponStrength;

        public void Visit(BikeShield bikeShield)
        {
            if (HealShield)
            {
                bikeShield.Health = 100.0f;
            }
        }

        public void Visit(BikeEngine bikeEngine)
        {
            float boost = bikeEngine.TurboBoost + TurboBoost;
            if (boost <= 0.0f)
            {
                bikeEngine.TurboBoost = 0.0f;
            } else if (boost >= bikeEngine.MaxTurboBoost)
            {
                bikeEngine.TurboBoost = bikeEngine.MaxTurboBoost;
            } else
            {
                bikeEngine.TurboBoost = boost;
            }
            
        }

        public void Visit(BikeWeapon bikeWeapon)
        {
            int range = bikeWeapon.Range + WeaponRange;
            if (range >= bikeWeapon.MaxRange)
            {
                bikeWeapon.Range = bikeWeapon.MaxRange;
            }
            else
            {
                bikeWeapon.Range = range;
            }

            float strength = bikeWeapon.Strength + Mathf.Round(bikeWeapon.Strength * WeaponStrength / 100);
            if (strength >= bikeWeapon.MaxStrength)
            {
                bikeWeapon.Strength = bikeWeapon.MaxStrength;
            } else
            {
                bikeWeapon.Strength = strength;
            }
        }
    }
}
