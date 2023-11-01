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
                int countSameValueDifferentPosition = 0;
                for (var i = 0; i < secret.Length; i++)
                {
                    var index = secret.IndexOf(guess[i]);
                    if (index == i)
                    {
                        countSameValueAndPosition++;
                    }
                    else if (index >= 0)
                    {
                        countSameValueDifferentPosition++;
                    }
                }

                return countSameValueAndPosition + "A" + countSameValueDifferentPosition + "B";
            }
        }
    }
}