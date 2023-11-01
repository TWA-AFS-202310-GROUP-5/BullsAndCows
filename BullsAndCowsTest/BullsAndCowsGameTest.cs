using BullsAndCows;
using Moq;
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
    }
}
