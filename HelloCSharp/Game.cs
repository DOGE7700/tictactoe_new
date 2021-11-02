using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp
{
    public class Game
    {
        const string ODD = "X";
        const string EVEN = "O";

        string PlayerTurn = ODD;

        public void Start()
        {
            string[] Grid = new string[] {
                "0","0","0",
                "0","0","0",
                "0","0","0"
            };

            Loop(() =>
            {
                PlayerTurn = PlayerTurn.Equals(ODD) ? ODD : EVEN;
                // take input
                var choice = Input(PlayerTurn);
                // change state
                var grid = Update(choice, PlayerTurn, Grid);
                // draw screen
                Draw(grid);
                // check end game
                return CheckEndGame(choice, grid);
            });
        }

        public void Loop(Func<bool> handler)
        {
            var run = true;
            while (run)
            {
                run = handler();
            }
            Console.WriteLine($"{PlayerTurn} has won!");
        }

        public int Input(string turn)
        {
            Console.WriteLine($"Turn {turn}:");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out var val))
            {
                return val;
            }
            return 0;
        }

        public string[] Update(int choice, string turn, string[] grid)
        {
            grid[choice - 1] = turn;
            return grid;
        }

        public void Draw(string[] lines)
        {
            Console.WriteLine(string.Format(@"
{0}{1}{2}
{3}{4}{5}
{6}{7}{8}
                ",
                lines));
        }

        public bool CheckEndGame(int choice, string[] grid)
        {
            if (SumHorizontal(choice, grid)
                || SumVertical(choice, grid)
                || SumDiagonal(choice, grid))
            {
                return true;
            }
            return false;
        }

        public bool SumHorizontal(int i, string[] grid)
        {
            // i = 
            // 0, 1, 2, 3, 4, 5, 6, 7, 8

            //      x
            //    y 1, 2, 3
            //      4, 5, 6
            //      7, 8, 9

            var x = i % 3;
            var y = i / 3;


            // y - 1 
            // y
            // y + 1
            var yy = ((y) + 3 * x);
            var y1 = ((y - 1) + 3 * x);
            var y2 = ((y + 1) + 3 * x);

            var result = 
                Check(grid, yy, PlayerTurn) +
                Check(grid, y1, PlayerTurn) +
                Check(grid, y2, PlayerTurn);

            return result == 3;
        }

        public bool SumVertical(int i, string[] grid)
        {
            return false;
        }

        public bool SumDiagonal(int i, string[] grid)
        {
            return false;
        }

        public int Check(string[] grid, int i, string value)
        {
            return value.Equals(grid[i]) ? 1 : 0;
        }
    }
}
