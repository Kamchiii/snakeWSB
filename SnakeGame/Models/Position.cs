namespace SnakeGame.Models;

public struct Position
{
    public int X { get; set; }
    public int Y { get; set; }
    
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    // Pomocnicze - porównywanie pozycji
    public static bool operator ==(Position a, Position b)
    {
        return a.X == b.X && a.Y == b.Y;
    }
    
    public static bool operator !=(Position a, Position b)
    {
        return !(a == b);
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is Position other)
            return this == other;
        return false;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}