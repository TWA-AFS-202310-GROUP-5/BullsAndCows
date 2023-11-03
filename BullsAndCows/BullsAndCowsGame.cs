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
            int bulls = 0;
            int cows = 0;

            for (int i = 0; i < guess.Length; i++)
            {
                if (guess[i] == secret[i])
                {
                    bulls++;
                }
            }

            for (int j = 0; j < guess.Length; j++)
            {
                for (int k = 0; k < guess.Length; k++)
                {
                    if (guess[k] == secret[j])
                    {
                        cows++;
                        break;
                    }
                }
            }

            cows -= bulls;

            return $"{bulls}A{cows}B";
        }
    }
}