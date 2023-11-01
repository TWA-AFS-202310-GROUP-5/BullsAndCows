using BullsAndCows;
using Moq;
using System.Runtime.InteropServices;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_create_BullsAndCowsGame()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            Assert.NotNull(game);
            Assert.True(game.CanContinue);
        }

        //-------------------------------------------Test Guess Method------------------------------------------
        [Fact]
        public void Should_return_4A0B_when_Guess_given_all_guessNumber_are_correct_and_right_position()
        {
            //When
            string expectedResult = "4A0B";
            string guessNumber = "1234";
            string secret = "1234";
            var mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);

            //Given
            var result = game.Guess(guessNumber);

            //Then
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("2143")]
        [InlineData("2341")]
        [InlineData("2413")]
        [InlineData("3142")]
        [InlineData("3412")]
        [InlineData("3421")]
        [InlineData("4123")]
        [InlineData("4312")]
        [InlineData("4321")]
        public void Should_return_0A4B_when_Guess_given_all_guessNumber_are_correct_and_worng_position(string guessNumber)
        {
            //When
            string expectedResult = "0A4B";
            string secret = "1234";
            var mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);

            //Given
            var result = game.Guess(guessNumber);

            //Then
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_return_0A0B_when_Guess_given_all_guessNumber_are_worng()
        {
            //When
            string expectedResult = "0A0B";
            string guessNumber = "6789";
            string secret = "1234";
            var mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);

            //Given
            var result = game.Guess(guessNumber);

            //Then
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_return_xA0B_when_Guess_given_x_in_range_0_4_where_x_guessNumber_are_correct_and_right_position_and_others_are_all_wrong()
        {
            //When
            string expectedResult = "2A0B";
            string guessNumber = "1289";
            string secret = "1234";
            var mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);

            //Given
            var result = game.Guess(guessNumber);

            //Then
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_return_0AyB_when_Guess_given_y_in_range_0_4_where_y_guessNumber_are_correct_and_wrong_position_and_others_are_all_wrong()
        {
            //When
            string expectedResult = "0A2B";
            string guessNumber = "3489";
            string secret = "1234";
            var mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);

            //Given
            var result = game.Guess(guessNumber);

            //Then
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_return_xAyB_when_Guess_given_x_y_both_in_range_0_4_where_x_guessNumber_are_correct_and_right_position_and_y_guessNumber_are_correct_and_wrong_position()
        {
            //When
            string expectedResult = "1A1B";
            string guessNumber = "1489";
            string secret = "1234";
            var mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);

            //Given
            var result = game.Guess(guessNumber);

            //Then
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_return_2A2B_when_Guess_given_2_guessNumber_are_correct_and_right_position_and_2_guessNumber_are_correct_and_wrong_position()
        {
            //When
            string expectedResult = "2A2B";
            string guessNumber = "1243";
            string secret = "1234";
            var mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);

            //Given
            var result = game.Guess(guessNumber);

            //Then
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_return_wrong_input_when_Guess_given_invalid_input()
        {
            //When
            string expectedResult = "Wrong Input, input again";
            string guessNumber = "abcd";
            string secret = "1234";
            var mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);

            //Given
            var result = game.Guess(guessNumber);

            //Then
            Assert.Equal(expectedResult, result);
        }

        //-------------------------------------------Test isGuessValid Method------------------------------------------
        [Fact]
        public void Should_return_true_when_isGuessValid_given_valid_numerical_nonRepeated_input()
        {
            //When
            bool expectedResult = true;
            string guessNumber = "1234";
            string secret = "1234";
            var mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);

            //Given
            var result = game.IsGuessValid(guessNumber);

            //Then
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_return_false_when_isGuessValid_given_nonNumerical_nonRepeated_input()
        {
            //When
            bool expectedResult = false;
            string guessNumber = "abcd";
            string secret = "1234";
            var mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);

            //Given
            var result = game.IsGuessValid(guessNumber);

            //Then
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_return_false_when_isGuessValid_given_numerical_repeated_input()
        {
            //When
            bool expectedResult = false;
            string guessNumber = "1123";
            string secret = "1234";
            var mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);

            //Given
            var result = game.IsGuessValid(guessNumber);

            //Then
            Assert.Equal(expectedResult, result);
        }

        //-------------------------------------------Test canContinue Method------------------------------------------
        [Fact]
        public void Should_be_true_when_CanContinue_given_first_try()
        {
            //When
            bool expectedResult = true;
            string secret = "1234";
            var mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);

            //Given
            var result = game.CanContinue;

            //Then
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_be_true_when_CanContinue_given_after_fifth_try()
        {
            //When
            bool expectedResult = true;
            string[] guessNumbers = { "2345", "3456", "4567", "5678", "6789" };
            string secret = "1234";
            var mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);
            foreach (string guess in guessNumbers)
            {
                game.Guess(guess);
            }

            //Given
            var result = game.CanContinue;

            //Then
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_be_false_when_CanContinue_given_after_sixth_try()
        {
            //When
            bool expectedResult = false;
            string[] guessNumbers = { "2345", "3456", "4567", "5678", "6789", "7890" };
            string secret = "1234";
            var mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);
            foreach (string guess in guessNumbers)
            {
                game.Guess(guess);
            }

            //Given
            var result = game.CanContinue;

            //Then
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_be_false_when_CanContinue_given_guess_successfully()
        {
            //When
            bool expectedResult = false;
            string guessNumber = "1234";
            string secret = "1234";
            var mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);
            game.Guess(guessNumber);

            //Given
            var result = game.CanContinue;

            //Then
            Assert.Equal(expectedResult, result);
        }
    }
}
