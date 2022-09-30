namespace Oechsle.Api.CrossCutting.Common
{
    public class Constants
    {
        public struct SystemStatusCode
        {
            public const int Required = 1;
            public const int Ok = 200;
            public const int TechnicalError = 400;
            public const int NotFound = 404;
            public const int ServerError = 500; 
        }
 
        public struct DateTimeFormats
        {
            public const string DD_MM_YYYY = "dd/MM/yyyy";
            public const string YYYY_MM_DD = "yyyy-MM-dd";
            public const string DD_MM_YYYY_HH_MM_SS = "dd/MM/yyyy HH:mm:ss";
            public const string DD_MM_YYYY_HH_MM_SS_STR = "yyyy-MM-dd hh:mm:ss";
            public const string DD_MM_YYYY_HH_MM_TT_12 = "dd/MM/yyyy hh:mm tt";
            public const string DD_MM_YYYY_HH_MM_SS_TT_12 = "dd/MM/yyyy hh:mm:ss tt";
            public const string DD_MM_YYYY_HH_MM_24 = "dd/MM/yyyy HH:mm";
            public const string DD_MM_YYYY_HH_MM_SS_FFF = "yyyyMMddHHmmssFFF";
            public const string DD_MM_YYY_HH_MM_SS = "ddMMyyyHHmmss";
            public const string HORA_INICIAL_DATA = "00:00:00";
            public const string HORA_FINAL_DATA = "14:00:00";
        }
        public struct StatusKey
        {
            public const string ActivatedStatus = "1";
            public const string InactiveStatus = "0";
        }

        public struct UserClaimsKeyApp
        {
            public const string IdUserKeyApp = "Id";
            public const string User = "User";
            public const string Password = "Password";
            public const string Status = "Status";
        }
    }
}
