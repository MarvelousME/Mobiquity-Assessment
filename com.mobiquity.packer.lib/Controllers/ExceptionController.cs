using com.mobiquity.packer.Responses;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace com.mobiquity.packer.Controllers
{
    /// <summary>
    /// Error Controller  that will throw the custom exception in the API
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ExceptionController : ControllerBase
    {
        [Route("exception")]
        public APIExceptionResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>(); //HttpContext request
            var exception = context?.Error; //Exception retrieved from the HttpContext request
            var code = 500; //Internal Server Error by default

            if (exception is APIException httpException)
            {
                code = (int)httpException.Status;
            }

            Response.StatusCode = code;

            return new APIExceptionResponse(exception ?? new Exception("Exception return had a value of NULL")); //return custom error
        }
    }
}
