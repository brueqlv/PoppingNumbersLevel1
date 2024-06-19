using PoppingNumbersLevel1.Helpers;
using PoppingNumbersLevel1.Models;
using PoppingNumbersLevel1.Services;

namespace PoppingNumbersLevel1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gameBoard = new GameBoard(5,5);
            var gameService = new GameService(gameBoard);
            var gameNumbers = new GameNumbers(1, 3);

            while (true)
            {
                Console.Clear();
                gameService.PrintBoard();

                var number = UserInputHelper.GetValidUserInputNumber(gameNumbers.From, gameNumbers.To);
                var row = UserInputHelper.GetValidUserInputNumber("row", gameBoard.Height);
                var col = UserInputHelper.GetValidUserInputNumber("col", gameBoard.Width);

                gameService.PlayerTurn(number, row, col);

                if (gameService.IsGameOver())
                {
                    break;
                }

                gameService.ComputerTurn();
                gameService.ClearConnectedNumbers();

                if (gameService.IsGameOver())
                {
                    break;
                }
            }
        }
    }
}
