using System.Text;

namespace com.mobiquity.packer.lib.Helpers
{
    /// <summary>
    /// Helper class to perform operations pertaining to a File
    /// </summary>
    public class FileHelper
    {
        #region Methods
        /// <summary>
        /// Method to copy stream, create and write file
        /// </summary>
        /// <param name="stream">stream to copy and save</param>
        /// <param name="downloadPath">file path to save output</param>
        public static async Task CopyStream(Stream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }

        /// <summary>
        /// Read all bytes of a file for a given file path
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <returns>byte[] array</returns>
        public static async Task<byte[]> ReadAllBytes(string filePath)
        {
            return await Task.Run(() => (File.ReadAllBytes(filePath)));
        }

        /// <summary>
        /// Method to convert byte[] array of a file to a UT8 encoded string
        /// </summary>
        /// <param name="fileBytes">File Byte[] Array</param>
        /// <returns>File Byte[] as UT8 Encoded string </returns>
        public static async Task<string> GetUTF8EncodedString(byte[] fileBytes)
        {
            return await Task.Run(() => (Encoding.UTF8.GetString(fileBytes)));
        }
        #endregion
    }
}
