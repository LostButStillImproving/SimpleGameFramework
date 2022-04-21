namespace SimpleGameFramework;

/// <summary>
/// An entity's position given by its xy coordinates.
/// Contained in <see cref="WorldObject"/>, <see cref="Creature"/>
/// </summary>
public class Position
{
    /// <summary>
    /// X coordinate
    /// </summary>
    public int X { get; set; }
    /// <summary>
    /// Y coordinate
    /// </summary>
    public int Y { get; set; }

    public override bool Equals(object? obj) {
        // If parameter is null return false.
        if (obj == null) {
            return false;
        }

        // If parameter cannot be cast to Pharmacy return false.
        var p = obj as Position;
        // Return true if the fields match:
        return p?.X == X &&p.Y == Y;
    }
    
    public override string ToString()
    {
        return $"X: {X} Y: {Y}";
    }
}