namespace com.mobiquity.packer.lib.Extensions
{
    /// <summary>
    /// Extension method for do a split by new line characters in a string
    /// </summary>
    public static class SplitStringExtension
    {
        public static string[] Lines(this string source)
        {
            return source.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
        }
    }
}
