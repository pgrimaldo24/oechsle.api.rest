namespace Oechsle.Api.CrossCutting.Common
{
    public class AppSetting
    {
        public ConnectionString ConnectionStrings { get; set; }
        public JWTConfiguration JWTConfigurations { get; set; }

        public class ConnectionString
        {
            public string DefaultConnectionSQL { get; set; } 
        }

        public class JWTConfiguration
        {
            public string Secret { get; set; }
            public int ExpirationTimeHours { get; set; }
            public string Iss { get; set; }
            public string Aud { get; set; }
        } 
    } 
}
