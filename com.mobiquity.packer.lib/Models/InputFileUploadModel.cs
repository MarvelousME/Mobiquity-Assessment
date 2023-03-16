using com.mobiquity.packer.Enums;
using Microsoft.AspNetCore.Http;

namespace com.mobiquity.packer.Models
{
    public class InputFileUploadModel
    {
        public IFormFile? FileDetails { get; set; }
        public FileType FileType { get; set; }
    }
}
