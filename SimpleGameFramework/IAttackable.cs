namespace SimpleGameFramework;

public abstract class IAttackable
{
    public abstract void ReceiveHit(Creature hitter,Creature receiver);

}