namespace SimpleGameFramework;

/// <summary>
/// A defence item that a <see cref="Creature"/> or <see cref="WorldObject"/> can carry
/// </summary>
public class DefenceItem
{
    /// <summary>
    /// Name of the defence item
    /// </summary>
    public virtual string Name { get; set; }
    /// <summary>
    /// Reduces damage of incoming attack
    /// </summary>
    public virtual int ReduceHitpoint { get; set; }
}