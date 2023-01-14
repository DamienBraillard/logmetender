namespace LogMeTender.Logging
{
    /// <summary>
    /// Defines the possible reasons a <see cref="LogReadEvent"/> has been emitted.
    /// </summary>
    public enum LogReadReason
    {
        /// <summary>
        /// The log source has been opened, this is the first set of log events that have been read.
        /// </summary>
        LogOpened,

        /// <summary>
        /// New log events have been read from the source.
        /// </summary>
        NewLogEvents,

        /// <summary>
        /// The log source has been cleared of it's events and new events starts to be emitted.
        /// This typically happens when the source is a log file that has been rolled.
        /// </summary>
        LogSourceReset
    }
}