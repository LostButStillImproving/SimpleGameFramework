namespace SimpleGameFramework;

public class WorldObject
{
    public Position Position { get; set; }
    public virtual string Name { get; set; }
    public virtual bool Lootable { get; set; }
    public virtual bool Removable { get; set; }
    
}