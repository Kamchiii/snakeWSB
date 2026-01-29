namespace SnakeGame.UI;

public static class Menu
{
    public static int Show()
    {
        Console.Clear();
        
        // Tytuł gry
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"
    ╔═══════════════════════════════════════╗
    ║            🐍 S N A K E 🐍            ║
    ╚═══════════════════════════════════════╝
        ");
        Console.ResetColor();
        
        // Opcje menu
        Console.WriteLine("       Wybierz tryb gry:\n");
        Console.WriteLine("         1 - Solo");
        Console.WriteLine("         2 - Co-op (2 graczy)");
        Console.WriteLine("         0 - Wyjście\n");
        
        Console.Write("       Twój wybór: ");
        
        // Czekaj na poprawny wybór
        while (true)
        {
            var key = Console.ReadKey(true);
            
            if (key.KeyChar == '1') return 1;
            if (key.KeyChar == '2') return 2;
            if (key.KeyChar == '0') return 0;
        }
    }
}