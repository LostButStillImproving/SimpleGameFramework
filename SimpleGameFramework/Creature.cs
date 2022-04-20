namespace SimpleGameFramework;


/// <summary>
/// A creature that exists within the <see cref="World"/>, both players and NPCs would inherit from Creature
/// Carries <see cref="AttackItem"/>, <see cref="DefenceItem"/>
/// </summary>
public class Creature
{
    /// <summary>
    /// A list of subscribers
    /// </summary>
    private List<World>? Subscribers { get; set; } = new();
    
    /// <summary>
    /// Name of the creature
    /// </summary>
    public virtual string Name { get; set; }
    
    /// <summary>
    /// The XY coordinate set of the creatures position
    /// </summary>
    public Position position { get; set; }
    
    /// <summary>
    /// An implementation of <see cref="IAttackBehavior"/> such that the creature can hit other creatures
    /// </summary>
    public IAttackBehavior AttackBehavior { get; set; }
    
    /// <summary>
    /// An implementation of <see cref="IAttackable"/> such that the creature can be hit by other creatures
    /// </summary>
    public IAttackable AttackleBehavior { get; set; }
    
    /// <summary>
    /// A creature can hold one AttackItem, used to calculate damage to other creatures
    /// </summary>
    public AttackItem AttackItem { get; set; }
    /// <summary>
    /// A creature can hold one DefenceItem, used to calculate damage received from other creatures
    /// </summary>
    public DefenceItem DefenceItem { get; set; }
    
    
    private int _hitpoint;
    /// <summary>
    /// The creatures total hp
    /// </summary>
    public virtual int Hitpoint
    {
        get => _hitpoint;

        set
        {
            _hitpoint = value;
            if (Hitpoint > 0) return;
            Console.WriteLine("check");
            RemoveSelf();
        }
    }

    

    /// <summary>
    /// Hits another creature using AttackBehavior
    /// </summary>
    /// <param name="creature"></param>
    public void Hit(Creature creature)
    {
        
        AttackBehavior.Hit(this ,creature);
    }
    
    /// <summary>
    /// Receives a hit from another creature, using AttackleBehavior
    /// </summary>
    /// <param name="creature"></param>
    public void ReceiveHit(Creature creature)
    {
        AttackleBehavior.ReceiveHit(creature, this);
    }

    public void Loot()
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// Notifies observers that this creature needs to be removed from the world
    /// </summary>
    protected virtual void RemoveSelf()
    {
        if (Subscribers == null) return;
        foreach (var subscriber in Subscribers.ToList())
        {
            subscriber.RemoveEntity(this);
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
