namespace Task_Test.Options.Config
{
    public class AuthSettings
    {
        public string Key { get; set; }
        public TimeSpan TokenLifetime { get; set; }
        public TimeSpan RefreshPeriod { get; set; }
        public bool ValidateLifetime { get; set; }

        public string Audience { get; set; }

        public string Issuer { get; set; }
    }
}
