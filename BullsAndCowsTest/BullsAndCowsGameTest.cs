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

        [Fact]
        public void Should_return_4A0B_when_Guess_given_guess_number_and_secret_are_same()
        {
            //given
            string guessNumber = "1234";
            string secret = "1234";
            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);
            //when
            string result = game.Guess(guessNumber);
            //then
            Assert.Equal("4A0B", result);
        }

        [Fact]
        public void Should_return_2A0B_when_Guess_given_guess_number_position_and_value_partial_right()
        {
            //given
            string guessNumber = "1289";
            string secret = "1234";
            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);
            //when
            string result = game.Guess(guessNumber);
            //then
            Assert.Equal("2A0B", result);
        }

        [Fact]
        public void Should_return_0A2B_when_Guess_given_guess_number_position_not_right_value_partial_right()
        {
            //given
            string guessNumber = "4389";
            string secret = "1234";
            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);
            //when
            string result = game.Guess(guessNumber);
            //then
            Assert.Equal("0A2B", result);
        }
    }
}
