namespace Task_Test.Options.Response
{
    public class AuthResult
    {
        public bool SuccessfulOperation { get; set; } = false;

        public List<string>? Errors { get; set; }

        public string AccessToken { get; set; }
    }
}
