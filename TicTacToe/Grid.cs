using System;
using System.Drawing;
using Console = Colorful.Console;
namespace TicTacToe
{
    public class Grid
    {
        public bool XWins = false;
        public bool OWins = false;
        public bool _gameOver = false;
        private int _width = 3;
        private int _height = 3;
        private string[,] _symbols;
        private ConsoleKey[]
        _numberkey =
        {
        ConsoleKey.D1,
        ConsoleKey.D2,
        ConsoleKey.D3,
        ConsoleKey.NumPad1,
        ConsoleKey.NumPad2,
        ConsoleKey.NumPad3
        };
        private enum _winXY { x1 = 0, y1 = 1, x2 = 2, y2 = 3, x3 = 4, y3 = 5 };
        private int[][] _winScenarios =
            {
            new int[] {0,0,0,1,0,2}, // Top Horizontal
            new int[] {1,0,1,1,1,2}, // Middle Horizontal
            new int[] {2,0,2,1,2,2}, // Bottom Horizontal
            new int[] {0,0,1,0,2,0}, // Left Vertical
            new int[] {0,1,1,1,2,1}, // Middle Vertical
            new int[] {0,2,1,2,2,2}, // right Vertical
            new int[] {0,0,1,1,2,2}, // top left to bottom right
            new int[] {2,0,1,1,0,2}  // bottom left to top right
            };
        private int _gridpos;
        private int _x;
        private int _y;

        public Grid(int width, int height)
        {
            _width = width;
            _height = height;
            InitGrid();
            Console.WriteLine("grid has been created");
        }

        public Grid()
        {
            _symbols = new string[_width, _height];
            InitGrid();
            Console.WriteLine("grid has been created");
        }

        public void InitGrid()
        {
            _symbols = new string[_width, _height];
            int i;
            for (i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    _symbols[i, j] = " ";
                }
            }
        }

        public void SetSquareToX()
        {
            Console.Write("Row (1-3) > ");
            int x = GetPosition() - 1;
            Console.Write("Col (1-3) > ");
            int y = GetPosition() - 1;
            if (_symbols[x, y] == "X" || _symbols[x, y] == "O")
            {
                Console.Clear();
                RenderGrid();
                Console.WriteLine("Try again Player 1!", Color.OrangeRed);
                SetSquareToX();
            }
            else _symbols[x, y] = "X";
        }

        public void SetSquareToO()
        {
            Console.Write("Row (1-3) > ");
            int x = GetPosition() - 1;
            Console.Write("Col (1-3) > ");
            int y = GetPosition() - 1;
            if (_symbols[x, y] == "X" || _symbols[x, y] == "O")
            {
                Console.Clear();
                RenderGrid();
                Console.WriteLine("Try again player 2!", Color.OrangeRed);
                SetSquareToO();
            }
            else _symbols[x, y] = "O";
        }

        public void RenderGrid()
        {
            Console.Clear();
            Console.WriteLine("Tic-Tac-Toe\n", Color.Aqua);
            int i;
            int j;
            int x = 2;
            for (i = 0; i < _height; i++)
            {
                Console.SetCursorPosition(3, x + i);
                for (j = 0; j < _width; j++)
                {
                    if (j < _width - 1)
                    {
                        Console.Write($"{_symbols[i, j]}", Color.Yellow);
                        Console.Write("|", Color.DarkGreen);
                    }
                    else Console.Write($"{_symbols[i, j]}\n", Color.Yellow);
                }
                x += 1;
                Console.SetCursorPosition(3, x + i);
                for (j = 0; j < _height; j++)
                {

                    if (i == _height - 1) break;
                    if (j < _width - 1) Console.Write("-+", Color.DarkGreen);
                    else Console.WriteLine("-", Color.DarkGreen);
                }
            }
            Console.WriteLine();
        }

        public int GetPosition()
        {
            ConsoleKeyInfo cki;
            cki = Console.ReadKey(true);
            if (_numberkey.Contains<ConsoleKey>(cki.Key))
                _gridpos = Int32.Parse(cki.KeyChar.ToString());
            else GetPosition();
            Console.WriteLine(_gridpos);
            return _gridpos;
        }

        public bool ScanGrid(string symbol)
        {
            int WinCount = 0;
            foreach (var scenario in _winScenarios)
            {

                if (_symbols[scenario[0], scenario[1]] == symbol) WinCount++;
                if (_symbols[scenario[2], scenario[3]] == symbol) WinCount++;
                if (_symbols[scenario[4], scenario[5]] == symbol) WinCount++;
                if (WinCount == 3 && symbol == "X") XWins = true;
                if (WinCount == 3 && symbol == "O") OWins = true;
                else WinCount = 0;
            }
            if (XWins == true || OWins == true)
            {
                _gameOver = true;
                return _gameOver;
            }

            return _gameOver = false;
        }


    }
}

