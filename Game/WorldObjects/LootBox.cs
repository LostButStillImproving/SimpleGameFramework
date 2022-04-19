using SimpleGameFramework;

namespace Game.WorldObjects;

public class LootBox : WorldObject
{
    public override string Name { get; set; } = "Lootbox";
    public override bool Lootable { get; set; } = true;
    public override bool Removable { get; set; } = true;

    public List<object> loot = new();
}