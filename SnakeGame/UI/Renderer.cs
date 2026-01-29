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
    /// Wyświetla informację pod planszą
    /// </summary>
    public static void DrawMessage(string message)
    {
        Console.SetCursorPosition(0, BoardHeight + 3);
        Console.WriteLine(message);
    }
}