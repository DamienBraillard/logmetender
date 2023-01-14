namespace LogMeTender.Logging
{
    /// <summary>
    /// The different normalized log message levels supported by the viewer.
    /// </summary>
    public enum LogEntryLevel
    {
        /// <summary>
        /// The message is a message aimed at tracing errors. It is the most verbose log level and generally only switched on in
        /// unusual situations.
        /// </summary>
        Trace,

        /// <summary>
        /// The message is aimed at debugging. It is a bit more verbose than the <see cref="Information"/>.
        /// </summary>
        Debug,

        /// <summary>
        /// The message is a standard information that can be used to track the execution of the program in standard situations.
        /// </summary>
        Information,

        /// <summary>
        /// The message is an indicator of a possible issue or degradation of functionality.
        /// </summary>
        Warning,

        /// <summary>
        /// The message is an indicator of a recoverable failure.
        /// </summary>
        Error,

        /// <summary>
        /// The message is an indicator of a critical error causing the complete failure of the application.
        /// </summary>
        Fatal
    }
}