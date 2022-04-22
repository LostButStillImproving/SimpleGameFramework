using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace SimpleGameFramework;


/// <summary>
/// The world where every <see cref="WorldObject"/> or <see cref="Creature"/> exists within.
/// Implements observer pattern to track all entities.
/// </summary>
public class World
{
    protected World(IConfiguration? configuration)
    {
        var mapUnBounded = Convert.ToBoolean(configuration?.GetSection("World").GetSection("MapUnbounded").Value);
        var maxY = Convert.ToInt16(
            configuration?.GetSection("World").GetSection("MaxY").Value);
        var maxX = Convert.ToInt16(
            configuration?.GetSection("World").GetSection("MaxX").Value);

        MapUnbounded = mapUnBounded;
        MaxX = maxX;
        MaxY = maxY;
    }
    protected World() {}

    /// <summary>
    /// Sets behavior for exiting the map, if true unit appears on opposite side,
    /// if false, unit cant cross border of the map. 
    /// </summary>
    public bool MapUnbounded { get; } = true;

    /// <summary>
    /// Maximum width of the world
    /// </summary>
    public int MaxX { get; init; } = 10;

    /// <summary>
    /// Maximum height of the world
    /// </summary>
    public int MaxY { get; init; } = 10;

    /// <summary>
    /// List of entities in the world
    /// </summary>
    public virtual List<object> Entities { get; } = new();

    /// <summary>
    /// Add an <see cref="WorldObject"/> to Entities and subscribes to it
    /// </summary>
    /// <param name="worldObject"></param>
    public virtual void AddEntity(WorldObject worldObject)
    {
        Entities.Add(worldObject);
        Trace.WriteLine($"Added entity: {worldObject.Name} at position: {worldObject.Position}");
        SubscribeToEntity(worldObject);
    }
    /// <summary>
    /// Add an <see cref="Creature"/> to Entities and subscribes to it
    /// </summary>
    /// <param name="creature"></param>
    public virtual void AddEntity(Creature creature)
    {
        Entities.Add(creature);
        Trace.WriteLine($"Added entity: {creature.Name} at position: {creature.Position}");
        SubscribeToEntity(creature);
    }
    
    /// <summary>
    /// Add a list of <see cref="Creature"/> and subscribes to them
    /// </summary>
    /// <param name="creatures"></param>
    public virtual void AddEntities(List<Creature> creatures)
    {
        foreach (var creature in creatures)
        {
            AddEntity(creature);
        }
    }
    
    /// <summary>
    /// Add a list of <see cref="WorldObject"/> and subscribes to them
    /// </summary>
    /// <param name="worldObjects"></param>
    public virtual void AddEntities(List<WorldObject> worldObjects)
    {
        foreach (var worldObject in worldObjects)
        {
            AddEntity(worldObject);
            SubscribeToEntity(worldObject);
        }
    }

    /// <summary>
    /// Removes an entity from Entities and unsubscribes from it
    /// </summary>
    /// <param name="entity"></param>
    public virtual void RemoveEntity(object entity)
    {
        Entities.Remove(entity);
        Trace.WriteLine($"Removed entity: {entity.GetType()}");

        switch (entity)
        {
            case Creature:
                UnsubscribeToEntity(entity);
                break;
            case WorldObject:
                UnsubscribeToEntity(entity);
                break;
        }
    }

    /// <summary>
    /// Unsubscribes from an entity
    /// </summary>
    /// <param name="entity"></param>
    public virtual void UnsubscribeToEntity(object entity)
    {
        switch (entity)
        {
            case Creature creature:
                creature.Unsubscribe(this);
                Trace.WriteLine($"{this} Unsubscribed from entity: {creature.Name}");
                break;
            case WorldObject worldObject:
                worldObject.Unsubscribe(this);
                Trace.WriteLine($"{this} Unsubscribed from entity: {worldObject.Name}");
                break;
        }
    }

    /// <summary>
    /// Subscribes to an entity
    /// </summary>
    /// <param name="entity"></param>
    public virtual void SubscribeToEntity(object entity)
    {
        switch (entity)
        {
            case Creature {Observe: false}:
                return;
            case Creature creature:
                creature.Subscribe(this);
                break;
            case WorldObject worldObject when !worldObject.Observe:
                return;
            case WorldObject worldObject:
                worldObject.Subscribe(this);
                break;
        }

        Trace.WriteLine($"{this} subscribed to Entity: {entity.GetType()}");
    }

    /// <summary>
    /// Checks whether the <see cref="Position"/> is occupited by another object
    /// </summary>
    /// <param name="position"></param>
    /// <returns>bool</returns>
    public virtual bool PositionIsOccupied(Position position)
    {
        bool CheckPosition(object entity)
        {
            return entity switch
            {
                Creature creature => creature.Position.Equals(position),
                WorldObject worldObject => worldObject.Position.Equals(position),
                _ => false
            };
        }

        return Entities.Any(CheckPosition);
    }
}