using com.mobiquity.packer.Models;

namespace com.mobiquity.packer.Interfaces
{
    /// <summary>
    /// TODO: If this was a requirement I would have implemented an Interface for the below methods
    /// </summary>
    public interface IFileService
    {
        string SaveFile(FileDetails fileDetail);
    }
}
