using SimpleGameFramework;

namespace Game.Behaviors.AttackBehaviors;

public class DoubleDamage : IAttackBehavior
{
    public void Hit(Creature hitter, Creature? receiver)
    {
        var enhanchedHitter = hitter;
        enhanchedHitter.AttackItem.Hitpoint *= 2;
        receiver.ReceiveHit(hitter);
    }
}