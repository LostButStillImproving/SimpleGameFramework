namespace SimpleGameFramework.Factories;

/// <summary>
/// A contract for creating monsters
/// </summary>
public interface ICreatureFactory
{
    /// <summary>
    /// Creates a given amount of monsters
    /// </summary>
    /// <param name="count"></param>
    /// <param name="world"></param>
    /// <returns></returns>
    public IEnumerable<Creature> CreateCreatures(int count, World world);
    
    public IEnumerable<Creature> CreateCreatures(int count);

}