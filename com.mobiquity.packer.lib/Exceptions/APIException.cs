using System.Net;

namespace com.mobiquity.packer
{
    /// <summary>
    /// Custom Exception that will be thrown in the API
    /// </summary>
    public class APIException : Exception
    {
        public HttpStatusCode Status { get; set; }
        public APIException(HttpStatusCode code, string msg) : base(msg)
        {
            this.Status = code;
        }
    }
}
