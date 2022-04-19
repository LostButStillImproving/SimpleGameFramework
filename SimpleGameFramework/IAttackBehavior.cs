namespace SimpleGameFramework;

public abstract class IAttackBehavior
{
    public abstract void Hit(Creature hitter,Creature receiver);
}