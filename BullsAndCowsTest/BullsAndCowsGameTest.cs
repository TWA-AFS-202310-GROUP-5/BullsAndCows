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
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            Assert.NotNull(game);
            Assert.True(game.CanContinue);
        }

        [Fact]
        public void Should_return_4A0B_when_guess_given_guess_number_and_secret_are_same()
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

        [Theory]
        [InlineData("1256")]
        [InlineData("5634")]
        [InlineData("5236")]
        [InlineData("1564")]
        public void Should_return_2A0B_when_guess_given_position_and_digit_partial_right(string guessNumber)
        {
            //given
            guessNumber = "1256";
            string secret = "1234";
            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);
            //when
            string result = game.Guess(guessNumber);
            //then
            Assert.Equal("2A0B", result);
        }

        [Theory]
        [InlineData("1562")]
        [InlineData("5263")]
        public void Should_return_1A1B_when_guess_given_position_and_digit_partial_right(string guessNumber)
        {
            //given
            string secret = "1234";
            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);

            //when
            string result = game.Guess(guessNumber);

            //then
            Assert.Equal("1A1B", result);
        }

        [Theory]
        [InlineData("5678")]
        public void Should_return_0A0B_when_guess_given_position_and_digit_all_wrong(string guessNumber)
        {
            //given
            guessNumber = "5678";
            string secret = "1234";
            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);

            //when
            string result = game.Guess(guessNumber);

            //then
            Assert.Equal("0A0B", result);
        }

        [Theory]
        [InlineData("4321")]
        public void Should_return_0A4B_when_guess_given_digit_correct_and_position_all_wrong(string guessNumber)
        {
            // given
            guessNumber = "4321";
            string secret = "1234";
            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);

            //when
            string result = game.Guess(guessNumber);

            //then
            Assert.Equal("0A4B", result);
        }
    }
}
