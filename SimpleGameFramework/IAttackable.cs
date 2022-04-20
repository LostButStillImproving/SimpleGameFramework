namespace SimpleGameFramework;
/// <summary>
/// An interface for entities that can be attacked. Eg you would implement this in <see cref="Creature"/>
/// </summary>
public abstract class IAttackable
{
    /// <summary>
    /// Method that allows classes that implements it, to be hit
    /// </summary>
    /// <param name="hitter"></param>
    /// <param name="receiver"></param>
    public abstract void ReceiveHit(Creature hitter,Creature receiver);

}