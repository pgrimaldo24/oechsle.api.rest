using System;
using System.Runtime.Serialization;
using static Oechsle.Api.CrossCutting.Common.Constants;

namespace Oechsle.Api.CrossCutting.Common
{
    public class TechnicalException : Exception, ISerializable
    {
        public string TransactionId { get; }
        public int ErrorCode { get; }
        public dynamic Data { get; set; }

        public TechnicalException(string message) : base(message)
        {
            this.ErrorCode = SystemStatusCode.TechnicalError;
            this.TransactionId = DateTime.Now.ToString(Constants.DateTimeFormats.DD_MM_YYYY_HH_MM_SS_FFF);
        }
    }
}
