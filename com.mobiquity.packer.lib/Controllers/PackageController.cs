using com.mobiquity.packer.lib.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace com.mobiquity.packer.Controllers
{
    /// <summary>
    /// Package Controller  that will contain the API method to calculate the items in a package
    /// </summary>
    [ApiController]
    public class PackageController : ControllerBase
    {
        #region Fields
        private readonly IHostingEnvironment _hostingEnvironment;

        private readonly ILogger<PackageController> _logger;
        #endregion

        #region Constants
        private const string INPUTPATH = @$"Files\Uploads\Inputs\example_input";
        private const string OUTPUTPATH = @"Files\Uploads\Outputs\example_output";
        #endregion

        #region Constructor
        public PackageController(ILogger<PackageController> logger, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }
        #endregion

        [HttpGet]
        [Route("pack/{filePath?}")]
        public ContentResult Pack(string filePath = INPUTPATH)
        {
            //Application'outputPackageContents base path
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            //Add contentRootPath to filePath to locate file
            filePath = String.IsNullOrEmpty(filePath) ? (contentRootPath + filePath) : (contentRootPath + INPUTPATH);

            if (!UtilityHelper.CheckIfFileExists(filePath))
                throw new APIException(System.Net.HttpStatusCode.NotFound, $"No file exists in file path: {filePath}");

            #region Process File
            var processed = Packer.pack(filePath);
            #endregion

            #region Check File Processed Correctly
            var isValid = String.IsNullOrEmpty(processed);
            if (!isValid)
            {
                var message = "File not processed correctly and values not displayed in correct format";

                //Log Error
                _logger.LogError(message);

                //Throw API Exception
                throw new APIException(System.Net.HttpStatusCode.NoContent, message);
            }
            #endregion


            //TODO: Could have written values to file and save it in the OUTPUTPATH

            return Content(processed);
        }
    }
}
