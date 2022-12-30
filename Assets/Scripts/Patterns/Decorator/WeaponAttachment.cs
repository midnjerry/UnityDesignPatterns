using UnityEngine;

namespace Chapter.Decorator
{
    [CreateAssetMenu(fileName ="NewWeaponAttachment", menuName ="Weapon/Attachment", order = 1)]
    public class WeaponAttachment : ScriptableObject, IWeapon
    {
        [Range(0, 50)]
        [Tooltip("Increase rate of firing per second")]
        [SerializeField] private float rate;

        [Range(0, 50)]
        [Tooltip("Increase weapon range")]
        [SerializeField] private float range;

        [Range(0, 100)]
        [Tooltip("Increase weapon strength")]
        [SerializeField] private float strength;

        [Range(0, -5)]
        [Tooltip("Reduce cooldown duration")]
        [SerializeField] private float cooldown;

        public string attachmentName;
        public GameObject attachmentPreFab;
        public string attachmentDescription;

        public float Rate { get { return rate; } }
        public float Range { get { return range; } }
        public float Strength { get { return strength; } }
        public float Cooldown { get { return cooldown; } }

    }
}
