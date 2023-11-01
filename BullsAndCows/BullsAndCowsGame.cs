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
                int countSameValueAndPosition = 0;
                int countSameValueNotPosition = 0;
                for (var i = 0; i < secret.Length; i++)
                {
                    if (secret.IndexOf(guess[i]) == i)
                    {
                        countSameValueAndPosition++;
                    }
                    else if (secret.IndexOf(guess[i]) >= 0)
                    {
                        countSameValueNotPosition++;
                    }
                }

                return countSameValueAndPosition + "A" + countSameValueNotPosition + "B";
            }
        }
    }
}