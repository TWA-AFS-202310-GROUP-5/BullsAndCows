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
            int x = 0;
            int y = 0;

            for (int i = 0; i < guess.Length; i++)
            {
                if (guess[i] == secret[i])
                {
                    x++;
                }
            }

            for (int j = 0; j < guess.Length; j++)
            {
                for (int k = 0; k < guess.Length; k++)
                {
                    if (guess[k] == secret[j])
                    {
                        y++;
                        break;
                    }
                }
            }

            y -= x;

            return $"{x}A{y}B";
        }
    }
}