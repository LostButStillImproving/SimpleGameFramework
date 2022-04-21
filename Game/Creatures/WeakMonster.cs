using System.Diagnostics;
using SimpleGameFramework;

namespace Game;

public class WeakMonster : Creature
{
    public override string Name { get; set; } = "Weakling";
    private int _hitpoint = 20;
}