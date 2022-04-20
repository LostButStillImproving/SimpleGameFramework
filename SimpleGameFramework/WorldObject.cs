namespace SimpleGameFramework;


/// <summary>
/// An object that exists within <see cref="World"/>
/// Can be looted for items <see cref="AttackItem"/> <see cref="DefenceItem"/>
/// </summary>
public class WorldObject
{
    /// <summary>
    /// Position of the world object
    /// </summary>
    public Position Position { get; set; }

    /// <summary>
    /// Collection of loot to be picked by creatures, typically the player
    /// </summary>
    public IEnumerable<object> Loot { get; }
    
    /// <summary>
    /// Nameof the world object
    /// </summary>
    public virtual string Name { get; set; }
    /// <summary>
    /// A boolean representing whether the world object can be looted or not
    /// </summary>
    public virtual bool Lootable { get; set; }
    /// <summary>
    /// A boolean representing whether the world object can be removed or not
    /// </summary>
    public virtual bool Removable { get; set; }
}