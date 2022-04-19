using SimpleGameFramework;

namespace Game;

public class WeakMonster : Creature
{
    public override string Name { get; set; } = "Weakling";
    public override int Hitpoint { get; set; } = 20;
}