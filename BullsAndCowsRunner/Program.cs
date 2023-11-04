using System;
using BullsAndCows;

namespace BullsAndCowsRunner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SecretGenerator secretGenerator = new SecretGenerator();
            BullsAndCowsGame game = new BullsAndCowsGame(secretGenerator);
            Console.WriteLine("Game Start: type your guess for this secret 4 digit number");
            while (game.CanContinue)
            {
                Console.Write("Your guess: ");
                var input = Console.ReadLine();
                var output = game.Guess(input);
                Console.WriteLine(output);
            }

            if (game.IsWinner)
            {
                Console.WriteLine("You Win!");
            }

            Console.WriteLine("Game Over");
        }
    }
}