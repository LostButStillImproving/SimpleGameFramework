using SimpleGameFramework;

namespace Game.Behaviors.AttackBehaviors;

public class DoubleAttack : IAttackBehavior

{ 
    public void Hit(Creature hitter, Creature? receiver)
    {
        receiver.ReceiveHit(hitter);
        if (receiver.Hitpoint < 0) return;
        receiver.ReceiveHit(hitter);
    }
    
}