namespace com.mobiquity.packer.lib.Helpers
{
    /// <summary>
    /// Helper class to service utility methods for various operations / functions
    /// </summary>
    public class UtilityHelper
    {
        #region Methods
        /// <summary>
        /// Check File Path and File Exists 
        /// </summary>
        /// <param name="filePath">Path to file</param>
        /// <returns>True, If file exists else False</returns>
        public static bool CheckIfFileExists(string filePath)
        {
            return (!String.IsNullOrEmpty(filePath) || !File.Exists(filePath));
        }
        #endregion
    }
}
