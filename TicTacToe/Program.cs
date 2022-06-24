// See https://aka.ms/new-console-template for more information
using TicTacToe;
using System.Drawing;
using Console = Colorful.Console;

ConsoleKeyInfo cki;
do
{
    Grid game = new Grid(3, 3);
    game.RenderGrid();
    int MoveCount = 0;
    while (!game._gameOver)
    {
        Console.WriteLine("Player 1 X's:", Color.Red);
        game.SetSquareToX();
        game.RenderGrid();
        game.ScanGrid("X");
        MoveCount++;
        if (game._gameOver) break;
        if (MoveCount == 9)break;
        
        Console.WriteLine("Player 2 O's:", Color.Navy);
        game.SetSquareToO();
        game.RenderGrid();
        game.ScanGrid("O");
        if (game._gameOver) break;
        MoveCount++;
    }
    if (game.XWins) Console.WriteLine("Player 1 X's Wins!", Color.ForestGreen);
    if (game.OWins) Console.WriteLine("Player 2 O's Wins!", Color.ForestGreen);
    if (!game.XWins && !game.OWins) Console.WriteLine("It is as draw!", Color.OrangeRed);
    Console.WriteLine("Game over");
    Console.Write("Play again Y/N > ");
    cki = Console.ReadKey();
} while (cki.Key != ConsoleKey.N);

Console.WriteLine("\nThanks for playing");



  




