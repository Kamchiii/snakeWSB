using SnakeGame.Models;

namespace SnakeGame.Engine;

public static class CollisionDetector
{
    /// <summary>
    /// Sprawdza czy wąż uderzył w ścianę
    /// </summary>
    public static bool HitsWall(Snake snake, int boardWidth, int boardHeight)
    {
        var head = snake.Head;
        return head.X < 0 || head.X >= boardWidth ||
               head.Y < 0 || head.Y >= boardHeight;
    }
    
    /// <summary>
    /// Sprawdza czy wąż uderzył w siebie
    /// </summary>
    public static bool HitsSelf(Snake snake)
    {
        var head = snake.Head;
        
        // Sprawdź od segmentu 1 (pomijamy głowę)
        for (int i = 1; i < snake.Segments.Count; i++)
        {
            if (snake.Segments[i] == head)
                return true;
        }
        
        return false;
    }
    
    /// <summary>
    /// Sprawdza czy wąż uderzył w drugiego węża
    /// </summary>
    public static bool HitsOtherSnake(Snake snake, Snake otherSnake)
    {
        var head = snake.Head;
        
        foreach (var segment in otherSnake.Segments)
        {
            if (segment == head)
                return true;
        }
        
        return false;
    }
    
    /// <summary>
    /// Sprawdza czy wąż zjadł jedzenie
    /// </summary>
    public static bool EatsFood(Snake snake, Food food)
    {
        return snake.Head == food.Position;
    }
}