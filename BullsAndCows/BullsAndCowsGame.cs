using System;
using System.Collections.Generic;
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
            List<char> existChar = new List<char>();
            foreach (char c in guess)
            {
                if (c < '0' || c > '9' || existChar.Contains(c))
                {
                    return false;
                }

                existChar.Add(c);
            }

            return true;
        }

        public string Guess(string guess)
        {
            if (!IsGuessValid(guess))
            {
                return "Wrong Input, input again";
            }

            char[] guessArr = guess.ToCharArray();

            (int numOfA, int numOfB) = CountMatchedAndCorrectDigits(guessArr);

            return $"{numOfA}A{numOfB}B";
        }

        private (int, int) CountMatchedAndCorrectDigits(char[] guessArr)
        {
            char[] secretArr = secret.ToCharArray();
            int fullMathedDigitNum = CountFullMatchGuessDigits(guessArr, secretArr);

            int correctNotMatchedDigitNum = CountCorrectGuessDigits(guessArr, secretArr) - fullMathedDigitNum;

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

        private int CountCorrectGuessDigits(char[] guessArr, char[] secretArr)
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