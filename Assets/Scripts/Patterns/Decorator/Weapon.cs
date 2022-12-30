namespace Chapter.Decorator
{
    public class Weapon: IWeapon
    {
        private readonly WeaponConfig _config;
        public float Range { 
            get { return _config.Range; } }
        
        public float Rate
        {
            get { return _config.Rate; }
        } 

        public float Strength
        {
            get { return _config.Strength; }
        }

        public float Cooldown
        {
            get { return _config.Cooldown; }
        }

        public Weapon(WeaponConfig weaponConfig)
        {
            _config = weaponConfig;
        }

    }
}
