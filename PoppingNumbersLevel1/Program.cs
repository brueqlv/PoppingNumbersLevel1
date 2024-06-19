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

            while (true)
            {
                Console.Clear();
                gameService.PrintBoard();

                gameService.PlayerTurn();

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

            Console.WriteLine("Game Over");
            Console.ReadLine();
        }
    }
}
