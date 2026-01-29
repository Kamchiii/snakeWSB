using SnakeGame.Engine;

namespace SnakeGame.UI;

public static class Renderer
{
    // Rozmiar planszy (wewnętrzna część, bez ramki)
    public const int BoardWidth = 40;
    public const int BoardHeight = 20;
    
    /// <summary>
    /// Rysuje pustą planszę z ramką
    /// </summary>
    public static void DrawBoard()
    {
        Console.Clear();
        Console.CursorVisible = false;
        
        // Górna ramka
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("╔" + new string('═', BoardWidth) + "╗");
        
        // Środek - puste wiersze z bocznymi ramkami
        for (int y = 0; y < BoardHeight; y++)
        {
            Console.Write("║");
            Console.Write(new string(' ', BoardWidth));
            Console.WriteLine("║");
        }
        
        // Dolna ramka
        Console.WriteLine("╚" + new string('═', BoardWidth) + "╝");
        Console.ResetColor();
    }
    
    /// <summary>
    /// Rysuje węża na planszy
    /// </summary>
    public static void DrawSnake(Snake snake, ConsoleColor color = ConsoleColor.Green)
    {
        Console.ForegroundColor = color;
        
        for (int i = 0; i < snake.Segments.Count; i++)
        {
            var segment = snake.Segments[i];
            
            // +1 bo ramka zajmuje pierwszą kolumnę/wiersz
            Console.SetCursorPosition(segment.X + 1, segment.Y + 1);
            
            if (i == 0)
            {
                // Głowa - inny znak
                Console.Write("@");
            }
            else
            {
                // Ciało
                Console.Write("O");
            }
        }
        
        Console.ResetColor();
    }
    
    /// <summary>
    /// Czyści pozycję na planszy (gdy wąż się rusza)
    /// </summary>
    public static void ClearPosition(int x, int y)
    {
        Console.SetCursorPosition(x + 1, y + 1);
        Console.Write(" ");
    }
    
    /// <summary>
    /// Wyświetla informację pod planszą
    /// </summary>
    public static void DrawMessage(string message)
    {
        Console.SetCursorPosition(0, BoardHeight + 3);
        Console.WriteLine(message);
    }
    
    /// <summary>
    /// Wyświetla punktację
    /// </summary>
    public static void DrawScore(int score1, int score2 = -1)
    {
        Console.SetCursorPosition(0, BoardHeight + 2);
        
        if (score2 == -1)
        {
            // Tryb solo
            Console.Write($"  Punkty: {score1}    ");
        }
        else
        {
            // Tryb coop
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"  P1: {score1}");
            Console.ResetColor();
            Console.Write("  |  ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"P2: {score2}");
            Console.ResetColor();
            Console.Write("    ");
        }
    }
}