using SimpleGameFramework;

namespace Game.AttackBehaviors;

public class NormalAttack : IAttackBehavior
{
    public void Hit(Creature hitter,Creature? receiver)
    {
        receiver.ReceiveHit(hitter);
    }
}