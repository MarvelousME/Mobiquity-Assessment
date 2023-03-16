namespace com.mobiquity.packer.Responses
{
    /// <summary>
    /// Http response class that will expose the custom APIException
    /// </summary>
    public class APIExceptionResponse
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public bool Status { get; set; }
        public int StatusCode { get; set; }

        public APIExceptionResponse(Exception ex)
        {
            Type = ex.GetType().Name;
            Message = ex.Message;
            Status = false;
            StackTrace = ex.ToString();
            StatusCode = 500;
            if (ex is APIException apiException)
            {
                this.StatusCode = (int)apiException.Status;
            }
        }
    }
}
