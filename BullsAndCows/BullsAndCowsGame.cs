using System;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private readonly string secret;

        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public bool IsGuessValid(string guess)
        {
            return true;
        }

        public string Guess(string guess)
        {
            char[] guessArr = guess.ToCharArray();

            (int numOfA, int numOfB) = CountMatchedAndCorrectDigits(guessArr);

            return $"{numOfA}A{numOfB}B";
        }

        private (int, int) CountMatchedAndCorrectDigits(char[] guessArr)
        {
            char[] secretArr = secret.ToCharArray();
            int fullMathedDigitNum = CountFullMatchGuessDigits(guessArr, secretArr);

            int correctNotMatchedDigitNum = CountCorrectNotMatchedGuessDigits(guessArr, secretArr) - fullMathedDigitNum;

            return (fullMathedDigitNum, correctNotMatchedDigitNum);
        }

        private int CountFullMatchGuessDigits(char[] guessArr, char[] secretArr)
        {
            int count = 0;
            for (int i = 0; i < guessArr.Length; i++)
            {
                if (guessArr[i] == secretArr[i])
                {
                    count++;
                }
            }

            return count;
        }

        private int CountCorrectNotMatchedGuessDigits(char[] guessArr, char[] secretArr)
        {
            int count = 0;
            for (int i = 0; i < guessArr.Length; i++)
            {
                if (secretArr.Contains(guessArr[i]))
                {
                    count++;
                }
            }

            return count;
        }
    }
}