/** Cool Trick
 * Use get shortcut to declare getter methods for property.
 * This implies that these properties should exist.
 **/
public interface IWeapon
{
    float Range { get; }
    float Rate { get; }
    float Strength { get; }
    float Cooldown { get; }
}
