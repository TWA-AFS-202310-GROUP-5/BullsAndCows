using BullsAndCows;
using Moq;
using System.Net.Sockets;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_create_BullsAndCowsGame()
        {
            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns("");

            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);
            Assert.NotNull(game);
        }

        [Fact]
        public void Should_return_4A0B_when_guess_given_guess_number_and_secret_are_same()
        {
            var guessNumber = "1234";
            var secret = "1234";

            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);

            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);
            var result = game.Guess(guessNumber);
            Assert.Equal("4A0B", result);
        }

        [Fact]
        public void Should_return_2A0B_when_guess_given_guess_number_and_secret_have_same_number_in_same_positions()
        {
            var guessNumber = "1234";
            var secret = "1205";

            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);

            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);
            var result = game.Guess(guessNumber);
            Assert.Equal("2A0B", result);
        }

        public void Should_return_1A1B_when_guess_given_guess_number_and_secret_have_same_number_in_same_positions_and_different_position()
        {
            var guessNumber = "1234";
            var secret = "1305";

            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);

            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);
            var result = game.Guess(guessNumber);
            Assert.Equal("1A1B", result);
        }

    }
}
