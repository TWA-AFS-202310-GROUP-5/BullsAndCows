using System;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private string secret;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            int bulls = 0;
            int totalSameNumber = 0;

            for (int i = 0; i < guess.Length; i++)
            {
                if (secret.IndexOf(guess[i]) != -1)
                {
                    totalSameNumber++;
                    if (i == secret.IndexOf(guess[i]))
                    {
                        bulls++;
                    }
                }
            }
            return $"{bulls}A{totalSameNumber-bulls}B";
        }
    }
}