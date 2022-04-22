using SimpleGameFramework;

namespace Game.DefenceBehavior;

public class NormalAttackable : IAttackable
{
    public void ReceiveHit(Creature hitter, Creature receiver)
    {
        int damageReceived;
        if (receiver.DefenceItem is not null)
        {
            damageReceived = hitter.AttackItem.Hitpoint - receiver.DefenceItem.ReduceHitpoint;
        }
        else
        {
            damageReceived = hitter.AttackItem.Hitpoint;
        }
        receiver.Hitpoint -= damageReceived;
    }
}