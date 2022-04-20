using SimpleGameFramework;

namespace Game;

public class WeakMonster : Creature
{
    public override string Name { get; set; } = "Weakling";
    private int _hitpoint = 20;
    public override int Hitpoint
    {
        get => _hitpoint;

        set
        {
            _hitpoint = value;
            if (Hitpoint > 0) return;
            Console.WriteLine("check");
            RemoveSelf();
        }
    }
}