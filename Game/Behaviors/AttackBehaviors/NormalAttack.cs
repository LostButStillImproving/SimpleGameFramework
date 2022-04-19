using SimpleGameFramework;

namespace Game.AttackBehaviors;

public class NormalAttack : IAttackBehavior
{
    public override void Hit(Creature hitter,Creature receiver)
    {
        receiver.ReceiveHit(hitter);
    }
}