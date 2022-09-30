namespace Oechsle.Api.CrossCutting.Dto
{
    public class CredentialDto
    {
        public string User { get; set; }
        public string Password { get; set; }
    }

    public class AuthDto
    {
        public string Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
    }
    public class JWTDto
    {
        public string Token { get; set; }
        public string Status { get; set; }
    }
}
