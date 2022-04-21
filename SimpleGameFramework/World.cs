using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace SimpleGameFramework;


/// <summary>
/// The world where every <see cref="WorldObject"/> or <see cref="Creature"/> exists within.
/// Implements observer pattern to track all entities.
/// </summary>
public class World
{
    protected World(IConfiguration configuration)
    {
        var mapUnBounded = Convert.ToBoolean(configuration.GetSection("World").GetSection("MapUnbounded").Value);
        var maxY = Convert.ToInt16(
            configuration.GetSection("World").GetSection("MaxY").Value);
        var maxX = Convert.ToInt16(
            configuration.GetSection("World").GetSection("MaxX").Value);

        MapUnbounded = mapUnBounded;
        MaxX = maxX;
        MaxY = maxY;
    }

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
    public List<object> Entities { get;} = new();

    /// <summary>
    /// Add an entity to Entities and subscribes to it
    /// </summary>
    /// <param name="entity"></param>
    public void AddEntity(object entity)
    {
        Entities.Add(entity);
        Trace.WriteLine($"Added entity: {entity.GetType()}");
        SubscribeToEntity(entity);
    }
    
    /// <summary>
    /// Removes an entity from Entities and unsubscribes from it
    /// </summary>
    /// <param name="entity"></param>
    public void RemoveEntity(object entity)
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
    private void UnsubscribeToEntity(object entity)
    {

        switch (entity)
        {
            case Creature creature:
                creature.Unsubscribe(this);
                break;
            case WorldObject worldObject:
                worldObject.Unsubscribe(this);
                break;
        }
        Trace.WriteLine($"{this} Unsubscribed from entity: {entity.GetType()}");

    }

    /// <summary>
    /// Subscribes to an entity
    /// </summary>
    /// <param name="entity"></param>
    private void SubscribeToEntity(object entity)
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
}