namespace SimpleGameFramework;


/// <summary>
/// An attack item that a <see cref="Creature"/> or <see cref="WorldObject"/> can carry
/// </summary>
public class AttackItem
{
    /// <summary>
    /// Name of the attackitem
    /// </summary>
    public virtual string Name { get; set; }
    /// <summary>
    /// Damage of the attack item
    /// </summary>
    public virtual int Hitpoint { get; set; }
    /// <summary>
    /// Range of the attack item
    /// </summary>
    public virtual int Range { get; set; }
}