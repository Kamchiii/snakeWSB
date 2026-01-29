using SnakeGame.Models;

namespace SnakeGame.Engine;

public class Food
{
    public Position Position { get; private set; }
    
    private readonly Random _random = new();
    private readonly int _boardWidth;
    private readonly int _boardHeight;
    
    public Food(int boardWidth, int boardHeight)
    {
        _boardWidth = boardWidth;
        _boardHeight = boardHeight;
        Respawn(new List<Position>());
    }
    
    /// <summary>
    /// Ustawia jedzenie w nowej losowej pozycji (omijając zajęte pola)
    /// </summary>
    public void Respawn(List<Position> occupiedPositions)
    {
        Position newPos;
        
        do
        {
            newPos = new Position(
                _random.Next(0, _boardWidth),
                _random.Next(0, _boardHeight)
            );
        }
        while (occupiedPositions.Contains(newPos));
        
        Position = newPos;
    }
}