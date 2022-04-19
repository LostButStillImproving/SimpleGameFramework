namespace SimpleGameFramework;

public class Creature
{
    public Position position { get; set; }
    
    public AttackItem AttackItem { get; set; }
    public DefenceItem DefenceItem { get; set; }
    public virtual string Name { get; set; }
    public virtual int Hitpoint { get; set; }
    public void Hit(){}
    public void ReceiveHit(){}
    public void Loot(){}
}
