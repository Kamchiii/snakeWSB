using SnakeGame.Models;

namespace SnakeGame.Engine;

public class Snake
{
    // Lista segmentów węża - pierwszy element to głowa
    public List<Position> Segments { get; private set; }
    
    // Aktualny kierunek ruchu
    public Direction CurrentDirection { get; private set; }
    
    // Czy wąż ma urosnąć przy następnym ruchu
    private bool _shouldGrow = false;
    
    public Snake(Position startPosition, Direction startDirection = Direction.Right)
    {
        CurrentDirection = startDirection;
        
        // Tworzymy węża z 2 segmentów
        Segments = new List<Position>();
        Segments.Add(startPosition); // Głowa
        
        // Ogon - za głową (w przeciwnym kierunku)
        var tailPosition = startDirection switch
        {
            Direction.Right => new Position(startPosition.X - 1, startPosition.Y),
            Direction.Left => new Position(startPosition.X + 1, startPosition.Y),
            Direction.Up => new Position(startPosition.X, startPosition.Y + 1),
            Direction.Down => new Position(startPosition.X, startPosition.Y - 1),
            _ => new Position(startPosition.X - 1, startPosition.Y)
        };
        Segments.Add(tailPosition);
    }
    
    /// <summary>
    /// Zmienia kierunek węża (nie pozwala zawrócić o 180°)
    /// </summary>
    public void ChangeDirection(Direction newDirection)
    {
        // Nie można zawrócić w przeciwnym kierunku
        bool isOpposite = (CurrentDirection == Direction.Up && newDirection == Direction.Down) ||
                          (CurrentDirection == Direction.Down && newDirection == Direction.Up) ||
                          (CurrentDirection == Direction.Left && newDirection == Direction.Right) ||
                          (CurrentDirection == Direction.Right && newDirection == Direction.Left);
        
        if (!isOpposite)
        {
            CurrentDirection = newDirection;
        }
    }
    
    /// <summary>
    /// Przesuwa węża o jedno pole w aktualnym kierunku
    /// </summary>
    public void Move()
    {
        // Oblicz nową pozycję głowy
        var head = Segments[0];
        var newHead = CurrentDirection switch
        {
            Direction.Up => new Position(head.X, head.Y - 1),
            Direction.Down => new Position(head.X, head.Y + 1),
            Direction.Left => new Position(head.X - 1, head.Y),
            Direction.Right => new Position(head.X + 1, head.Y),
            _ => head
        };
        
        // Wstaw nową głowę na początek
        Segments.Insert(0, newHead);
        
        // Usuń ogon (chyba że wąż ma rosnąć)
        if (_shouldGrow)
        {
            _shouldGrow = false;
        }
        else
        {
            Segments.RemoveAt(Segments.Count - 1);
        }
    }
    
    /// <summary>
    /// Oznacza że wąż ma urosnąć przy następnym ruchu
    /// </summary>
    public void Grow()
    {
        _shouldGrow = true;
    }
    
    /// <summary>
    /// Zwraca pozycję głowy
    /// </summary>
    public Position Head => Segments[0];
}