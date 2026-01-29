using SnakeGame.UI;
using SnakeGame.Engine;
using SnakeGame.Models;

// === MENU ===
int choice = Menu.Show();

if (choice == 0)
{
    Console.Clear();
    Console.WriteLine("Do zobaczenia! 👋");
    return;
}

bool isCoop = choice == 2;

// === INICJALIZACJA ===
Renderer.DrawBoard();

// Gracz 1 - zielony wąż
var snake1 = new Snake(
    new Position(Renderer.BoardWidth / 4, Renderer.BoardHeight / 2),
    Direction.Right
);
int score1 = 0;

// Gracz 2 - niebieski wąż (tylko w coop)
Snake? snake2 = null;
int score2 = 0;

if (isCoop)
{
    snake2 = new Snake(
        new Position(Renderer.BoardWidth * 3 / 4, Renderer.BoardHeight / 2),
        Direction.Left
    );
}

// Jedzenie
var food = new Food(Renderer.BoardWidth, Renderer.BoardHeight);

// Prędkość gry (ms między klatkami)
int gameSpeed = 100;

// === GAME LOOP ===
bool gameOver = false;
string gameOverMessage = "";

while (!gameOver)
{
    // 1. Pobierz input
    var (input1, input2) = InputHandler.GetInput();
    
    if (input1.HasValue)
        snake1.ChangeDirection(input1.Value);
    
    if (isCoop && input2.HasValue && snake2 != null)
        snake2.ChangeDirection(input2.Value);
    
    // 2. Zapamiętaj stare pozycje ogonów (do czyszczenia)
    var oldTail1 = snake1.Segments[^1];
    Position? oldTail2 = isCoop && snake2 != null ? snake2.Segments[^1] : null;
    
    // 3. Ruch
    snake1.Move();
    snake2?.Move();
    
    // 4. Kolizje - Gracz 1
    if (CollisionDetector.HitsWall(snake1, Renderer.BoardWidth, Renderer.BoardHeight))
    {
        gameOver = true;
        gameOverMessage = isCoop ? "Gracz 2 wygrywa! (P1 uderzył w ścianę)" : "Game Over! Uderzenie w ścianę";
    }
    else if (CollisionDetector.HitsSelf(snake1))
    {
        gameOver = true;
        gameOverMessage = isCoop ? "Gracz 2 wygrywa! (P1 zjadł siebie)" : "Game Over! Zjadłeś siebie";
    }
    else if (isCoop && snake2 != null && CollisionDetector.HitsOtherSnake(snake1, snake2))
    {
        gameOver = true;
        gameOverMessage = "Gracz 2 wygrywa! (P1 uderzył w P2)";
    }
    
    // 5. Kolizje - Gracz 2 (tylko coop)
    if (!gameOver && isCoop && snake2 != null)
    {
        if (CollisionDetector.HitsWall(snake2, Renderer.BoardWidth, Renderer.BoardHeight))
        {
            gameOver = true;
            gameOverMessage = "Gracz 1 wygrywa! (P2 uderzył w ścianę)";
        }
        else if (CollisionDetector.HitsSelf(snake2))
        {
            gameOver = true;
            gameOverMessage = "Gracz 1 wygrywa! (P2 zjadł siebie)";
        }
        else if (CollisionDetector.HitsOtherSnake(snake2, snake1))
        {
            gameOver = true;
            gameOverMessage = "Gracz 1 wygrywa! (P2 uderzył w P1)";
        }
    }
    
    if (gameOver) break;
    
    // 6. Jedzenie
    var allSegments = new List<Position>(snake1.Segments);
    if (snake2 != null) allSegments.AddRange(snake2.Segments);
    
    if (CollisionDetector.EatsFood(snake1, food))
    {
        snake1.Grow();
        score1++;
        food.Respawn(allSegments);
    }
    
    if (snake2 != null && CollisionDetector.EatsFood(snake2, food))
    {
        snake2.Grow();
        score2++;
        food.Respawn(allSegments);
    }
    
    // 7. Render
    Renderer.ClearPosition(oldTail1.X, oldTail1.Y);
    if (oldTail2.HasValue)
        Renderer.ClearPosition(oldTail2.Value.X, oldTail2.Value.Y);
    
    Renderer.DrawFood(food);
    Renderer.DrawSnake(snake1, ConsoleColor.Green);
    
    if (snake2 != null)
        Renderer.DrawSnake(snake2, ConsoleColor.Cyan);
    
    if (isCoop)
        Renderer.DrawScore(score1, score2);
    else
        Renderer.DrawScore(score1);
    
    // 8. Czekaj
    Thread.Sleep(gameSpeed);
}

// === GAME OVER ===
Console.Clear();
Console.WriteLine("\n");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("   ╔═══════════════════════════════════════╗");
Console.WriteLine("   ║             GAME OVER!                ║");
Console.WriteLine("   ╚═══════════════════════════════════════╝");
Console.ResetColor();
Console.WriteLine();
Console.WriteLine($"   {gameOverMessage}");
Console.WriteLine();

if (isCoop)
{
    Console.WriteLine($"   Wynik P1: {score1}");
    Console.WriteLine($"   Wynik P2: {score2}");
}
else
{
    Console.WriteLine($"   Twój wynik: {score1}");
}

Console.WriteLine("\n   Naciśnij dowolny klawisz...");
Console.ReadKey(true);
Console.CursorVisible = true;