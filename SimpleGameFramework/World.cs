namespace SimpleGameFramework;


/// <summary>
/// The world where every <see cref="WorldObject"/> or <see cref="Creature"/> exists within.
/// Implements observer pattern to track all entities.
/// </summary>
public class World 
{
    
    /// <summary>
    /// Maximum width of the world
    /// </summary>
    public int MaxX { get; set; }
    /// <summary>
    /// Maximum height of the world
    /// </summary>
    public int MaxY { get; set; }
    /// <summary>
    /// List of entities in the world
    /// </summary>
    public List<object> Entities { get;} = new();

    /// <summary>
    /// Add an entity to Entities and subscribes to it
    /// </summary>
    /// <param name="entity"></param>
    public virtual void AddEntity(object entity)
    {
        Console.WriteLine("Ádd Entity");
        Entities.Add(entity);
        SubscribeToEntity(entity);
    }
    
    /// <summary>
    /// Removes an entity from Entities and unsubscribes from it
    /// </summary>
    /// <param name="entity"></param>
    public virtual void RemoveEntity(object entity)
    {
        Console.WriteLine("Remove Entity");
        Entities.Remove(entity);
        UnsubscribeToEntity(entity);
    }

    /// <summary>
    /// Unsubscribes from an entity
    /// </summary>
    /// <param name="entity"></param>
    protected virtual void UnsubscribeToEntity(object entity)
    {
        Console.WriteLine("Unsubscribe to Entity");
        if (entity is Creature creature)
        {
            creature.Unsubscribe(this);
        } 
    }

    /// <summary>
    /// Subscribes to an entity
    /// </summary>
    /// <param name="entity"></param>
    protected virtual void SubscribeToEntity(object entity)
    {
        Console.WriteLine("Subscribing to Entity");
        if (entity is Creature creature)
        {
            creature.Subscribe(this);
        } 
    }
}