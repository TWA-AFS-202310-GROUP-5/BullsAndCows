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
        public void Should_return_4A0B_when_Game_given_guess_same_as_secret()
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
        public void Should_return_2A0B_when_Game_given_position_and_value_partical_right()
        {
            //given
            string guessNumber = "1278";
            string secret = "1234";

            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);

            //when
            string result = game.Guess(guessNumber);

            //then
            Assert.Equal("2A0B", result);
        }
    }
}
