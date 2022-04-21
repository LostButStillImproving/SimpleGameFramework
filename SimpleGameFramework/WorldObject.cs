using System.Diagnostics;

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
    
    private List<World>? Subscribers { get; set; } = new();

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

    public bool Observe { get; set; } = true;

    protected virtual void RemoveSelf()
    {
        if (Subscribers == null) return;
        foreach (var subscriber in Subscribers.ToList())
        {
            
            subscriber.RemoveEntity(this);
            var message = $"{Name} was removed from the world";
            Trace.WriteLine(message);
        }
    }
    
    /// <summary>
    /// Lets an observer subscribe to an instance of creature
    /// </summary>
    /// <param name="world"></param>
    public virtual void Subscribe(World world)
    {
        Subscribers?.Add(world);
    }
    
    /// <summary>
    /// Removes a subscriber from the list of subscribers
    /// </summary>
    /// <param name="world"></param>
    public virtual void Unsubscribe(World world)
    {
        if (Subscribers != null && Subscribers.Contains(world))
        {
            Subscribers.Remove(world);
        }
    }
}