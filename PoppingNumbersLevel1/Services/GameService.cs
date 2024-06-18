using PoppingNumbersLevel1.Models;

namespace PoppingNumbersLevel1.Services
{
    public class GameService(GameBoard gameBoard)
    {
        private const int NumberFrom = 1;
        private const int NumberTo = 3;
        private readonly Random _gameRandom = new();

        public void PrintBoard()
        {
            for (var i = 0; i < gameBoard.Height; i++)
            {
                var sb1 = new List<string>();
                var lines = new List<string>();
                for (var j = 0; j < gameBoard.Width; j++)
                {
                    sb1.Add(gameBoard.Board[i, j] == 0 ? "   " : " " + gameBoard.Board[i, j] + " ");
                    lines.Add("---");
                }
                Console.WriteLine(string.Join("|", sb1));

                if (i < gameBoard.Height - 1)
                {
                    Console.WriteLine(string.Join("|", lines));
                }
            }
        }

        public void PlayerTurn(int number, int row, int col)
        {
            while (true)
            {

                if (gameBoard.Board[row - 1, col - 1] == 0)
                {
                    gameBoard.Board[row - 1, col - 1] = number;
                    break;
                }

                Console.WriteLine("Field is already occupied, try again.");
            }
        }

        public void ComputerTurn()
        {
            var numbersPlaced = 0;
            while (numbersPlaced < 3)
            {
                var row = _gameRandom.Next(gameBoard.Height);
                var col = _gameRandom.Next(gameBoard.Width);

                if (gameBoard.Board[row, col] == 0)
                {
                    gameBoard.Board[row, col] = _gameRandom.Next(NumberFrom, NumberTo + 1);
                    numbersPlaced++;
                }
            }
        }

        public bool IsGameOver()
        {
            for (var i = 0; i < gameBoard.Height; i++)
            {
                for (var j = 0; j < gameBoard.Width; j++)
                {
                    if (gameBoard.Board[i, j] == 0)
                    {
                        return false;
                    }
                }
            }

            Console.WriteLine("Game Over! No more spaces left.");
            Console.ReadLine();

            return true;
        }

        public void ClearConnectedNumbers()
        {
            var toClear = new bool[gameBoard.Height, gameBoard.Width];

            CheckConnections(toClear, 0, 1);  // Horizontal
            CheckConnections(toClear, 1, 0);  // Vertical
            CheckConnections(toClear, 1, 1);  // Diagonal
            CheckConnections(toClear, 1, -1); // Reverse Diagonal

            ClearMarkedCells(toClear);
        }

        private void CheckConnections(bool[,] toClear, int rowIncrement, int colIncrement)
        {
            var height = gameBoard.Height;
            var width = gameBoard.Width;

            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    MarkConnectedCells(toClear, i, j, rowIncrement, colIncrement);
                }
            }
        }

        private void MarkConnectedCells(bool[,] toClear, int startRow, int startCol, int rowIncrement, int colIncrement)
        {
            var current = gameBoard.Board[startRow, startCol];
            if (current == 0) return;

            var count = 1;
            var row = startRow + rowIncrement;
            var col = startCol + colIncrement;

            while (IsValidPosition(row, col) && gameBoard.Board[row, col] == current)
            {
                count++;
                row += rowIncrement;
                col += colIncrement;
            }

            if (count >= 3)
            {
                for (var k = 0; k < count; k++)
                {
                    toClear[startRow + k * rowIncrement, startCol + k * colIncrement] = true;
                }
            }
        }

        private bool IsValidPosition(int row, int col)
        {
            return row >= 0 && row < gameBoard.Height && col >= 0 && col < gameBoard.Width;
        }

        private void ClearMarkedCells(bool[,] toClear)
        {
            for (var i = 0; i < gameBoard.Height; i++)
            {
                for (var j = 0; j < gameBoard.Width; j++)
                {
                    if (toClear[i, j])
                    {
                        gameBoard.Board[i, j] = 0;
                    }
                }
            }
        }

    }
}
