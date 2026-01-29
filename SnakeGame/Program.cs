using SnakeGame.UI;
using SnakeGame.Engine;
using SnakeGame.Models;

// Pokaż menu i pobierz wybór
int choice = Menu.Show();

if (choice == 0)
{
    Console.Clear();
    Console.WriteLine("Do zobaczenia! 👋");
    return;
}

// Tryb gry
bool isCoop = choice == 2;

// Rysuj planszę
Renderer.DrawBoard();

// Stwórz węża na środku planszy
var snake1 = new Snake(
    new Position(Renderer.BoardWidth / 2, Renderer.BoardHeight / 2),
    Direction.Right
);

// Rysuj węża
Renderer.DrawSnake(snake1, ConsoleColor.Green);

// Jeśli coop, stwórz drugiego węża
if (isCoop)
{
    var snake2 = new Snake(
        new Position(Renderer.BoardWidth / 2, Renderer.BoardHeight / 2 - 3),
        Direction.Right
    );
    Renderer.DrawSnake(snake2, ConsoleColor.Cyan);
    Renderer.DrawScore(0, 0);
}
else
{
    Renderer.DrawScore(0);
}

Renderer.DrawMessage("Naciśnij dowolny klawisz aby wyjść...");

Console.ReadKey(true);
Console.Clear();
Console.CursorVisible = true;