using SnakeGame.Models;

namespace SnakeGame.Engine;

public static class InputHandler
{
    /// <summary>
    /// Sprawdza czy jest wciśnięty klawisz i zwraca kierunki dla obu graczy
    /// </summary>
    public static (Direction? player1, Direction? player2) GetInput()
    {
        if (!Console.KeyAvailable)
            return (null, null);
        
        var key = Console.ReadKey(true);
        
        // Gracz 1 - WASD
        Direction? p1 = key.Key switch
        {
            ConsoleKey.W => Direction.Up,
            ConsoleKey.S => Direction.Down,
            ConsoleKey.A => Direction.Left,
            ConsoleKey.D => Direction.Right,
            _ => null
        };
        
        // Gracz 2 - Strzałki
        Direction? p2 = key.Key switch
        {
            ConsoleKey.UpArrow => Direction.Up,
            ConsoleKey.DownArrow => Direction.Down,
            ConsoleKey.LeftArrow => Direction.Left,
            ConsoleKey.RightArrow => Direction.Right,
            _ => null
        };
        
        return (p1, p2);
    }
    
    /// <summary>
    /// Czyści bufor klawiszy (żeby nie było opóźnień)
    /// </summary>
    public static void ClearBuffer()
    {
        while (Console.KeyAvailable)
            Console.ReadKey(true);
    }
}