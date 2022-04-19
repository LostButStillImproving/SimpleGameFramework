namespace SimpleGameFramework;

public class Creature
{
    public virtual string Name { get; set; }

    public Position position { get; set; }
    
    public IAttackBehavior AttackBehavior { get; set; }
    public IAttackable AttackleBehavior { get; set; }
    public AttackItem AttackItem { get; set; }
    public DefenceItem DefenceItem { get; set; }
    private int _hitpoint;
    public virtual int Hitpoint
    {
        get => _hitpoint;

        set
        {
            _hitpoint = value;
            if (_hitpoint <= 0)
            {
                RemoveSelf();
            }
        }
    }

    private void RemoveSelf()
    {
        throw new NotImplementedException();
    }

    public void Hit(Creature creature)
    {
        AttackBehavior.Hit(this ,creature);
    }
    
    public void ReceiveHit(Creature creature)
    {
        AttackleBehavior.ReceiveHit(creature, this);
    }
   
    public void Loot(){}
}
