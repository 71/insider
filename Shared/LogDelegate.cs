namespace Insider
{
    /// <summary>
    /// Importance of the message.
    /// </summary>
    public enum MessageImportance : byte
    {
        /// <summary>
        /// Non-critical yet useful information.
        /// </summary>
        Info,
        /// <summary>
        /// Information useful for debugging.
        /// </summary>
        Debug,
        /// <summary>
        /// Warning ; will not stop the build process.
        /// </summary>
        Warning,
        /// <summary>
        /// Error ; will stop the build process.
        /// </summary>
        Error
    }

    /// <summary>
    /// Delegate that logs informations or errors to the build process.
    /// </summary>
    internal delegate void LogDelegate(object sender, string message, MessageImportance importance);
}
