namespace SimpleGameFramework;

public class Creature
{
    public Position position { get; set; }
    
    public AttackItem AttackItem { get; set; }
    public DefenceItem DefenceItem { get; set; }
    public virtual string Name { get; set; }
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
        creature.ReceiveHit(this);
    }

    public void ReceiveHit(Creature creature)
    {
        Hitpoint -= creature.AttackItem.Hitpoint;
    }
    public void Loot(){}
}
