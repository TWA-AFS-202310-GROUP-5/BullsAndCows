using System;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private readonly string secret;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            if (guess == secret)
            {
                return "4A0B";
            }
            else
            {
                int bulls = 0;
                int cows = 0;
                for (var i = 0; i < secret.Length; i++)
                {
                    var index = secret.IndexOf(guess[i]);
                    if (index == i)
                    {
                        bulls++;
                    }
                    else if (index >= 0)
                    {
                        cows++;
                    }
                }

                return $"{bulls}A{cows}B";
            }
        }
    }
}