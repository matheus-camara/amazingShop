namespace amazingShop.Api.Settings
{
    public sealed class AppSettings
    {
        public readonly string SigningKey;

        public AppSettings(string signingKey)
        {
            SigningKey = signingKey;
        }
    }
}