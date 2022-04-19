using SimpleGameFramework;

namespace Game;

public class Player : Creature
{
    public override string Name { get; set; }
    public override int Hitpoint { get; set; } = 100;
}