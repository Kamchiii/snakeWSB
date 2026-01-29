using SnakeGame.UI;

// Pokaż menu i pobierz wybór
int choice = Menu.Show();

if (choice == 0)
{
    Console.Clear();
    Console.WriteLine("Do zobaczenia! 👋");
    return;
}

// Na razie pokazujemy tylko planszę
string mode = choice == 1 ? "Solo" : "Co-op";

Renderer.DrawBoard();
Renderer.DrawMessage($"Tryb: {mode} | Naciśnij dowolny klawisz aby wyjść...");

Console.ReadKey(true);
Console.Clear();
Console.CursorVisible = true;