namespace SimpleGameFramework;
/// <summary>
/// An interface for entities that can attack. Eg you would implement this in <see cref="Creature"/>
/// </summary>
public interface IAttackBehavior
{
    /// <summary>
    ///  Method that allows classes that implements it, to hit
    /// </summary>
    /// <param name="hitter"></param>
    /// <param name="receiver"></param>
    public void Hit(Creature hitter,Creature? receiver);
}