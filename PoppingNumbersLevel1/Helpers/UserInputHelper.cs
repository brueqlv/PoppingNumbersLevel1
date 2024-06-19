namespace PoppingNumbersLevel1.Helpers
{
    public static class UserInputHelper
    {
        public static int GetValidUserInputNumber(int from, int to)
        {
            while (true)
            {
                Console.Write($"Enter a number ({from}-{to}): ");
                var numberInput = Console.ReadLine();

                if (int.TryParse(numberInput, out var result))
                {
                    if (result >= from && result <= to)
                    {
                        return result;
                    }
                }

                Console.WriteLine("Invalid input, try again.");
            }
        }

        public static int GetValidUserInputNumber(string message, int max)
        {
            while (true)
            {
                Console.Write($"Enter {message} (1 - {max}): ");
                var numberInput = Console.ReadLine();

                if (int.TryParse(numberInput, out var result))
                {
                    if (result >= 1 && result <= max)
                    {
                        return result;
                    }
                }

                Console.WriteLine("Invalid input, try again.");
            }
        }
    }
}
