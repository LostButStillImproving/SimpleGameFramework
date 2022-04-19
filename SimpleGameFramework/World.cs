namespace SimpleGameFramework;

public class World
{
    public int MaxX { get; set; }
    public int MaxY { get; set; }
    public List<object> entities { get; set; } = new();
}