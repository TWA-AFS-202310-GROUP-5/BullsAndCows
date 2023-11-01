namespace BullsAndCows
{
    internal class SecretGeneratorDouble : SecretGenerator
    {
        private readonly string secret = "1234";

        public SecretGeneratorDouble(string secret)
        {
            this.secret = secret;
        }

        public override string GenerateSecret()
        {
            return secret;
        }
    }
}
