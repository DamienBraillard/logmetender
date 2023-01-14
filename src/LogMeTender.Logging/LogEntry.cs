using System;

namespace LogMeTender.Logging
{
    /// <summary>
    /// Represents a logged message entry.
    /// </summary>
    public class LogEntry
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="LogEntry"/> class.
        /// </summary>
        /// <param name="entryNumber">The one-based sequence number of the entry within the source.</param>
        /// <param name="timeStamp">
        /// The <see cref="DateTime"/> that indicates the date and time at which the log message has been
        /// emitted.
        /// </param>
        /// <param name="level">The <see cref="LogEntryLevel"/> that represents the severity level of the message.</param>
        /// <param name="source">The source that emitted this log message.</param>
        /// <param name="message">The message that was logged.</param>
        /// <param name="error">
        /// The detailed description of the error if one is associated with this message; <c>null</c> if no
        /// error is associated with the message.
        /// </param>
        public LogEntry(int entryNumber, DateTime timeStamp, LogEntryLevel level, string source, string message, string? error)
        {
            EntryNumber = entryNumber;
            TimeStamp = timeStamp;
            Level = level;
            Source = source;
            Message = message;
            Error = error;
        }

        /// <summary>
        /// Gets the one-based sequence number of the entry within the source.
        /// </summary>
        public int EntryNumber { get; }

        /// <summary>
        /// Gets the <see cref="DateTimeOffset"/> that indicates the date and time at which the log message has been emitted.
        /// </summary>
        public DateTime TimeStamp { get; }

        /// <summary>
        /// Gets the <see cref="LogEntryLevel"/> that represents the severity level of the message.
        /// </summary>
        public LogEntryLevel Level { get; }

        /// <summary>
        /// Gets the source that emitted this log message.
        /// </summary>
        public string Source { get; }

        /// <summary>
        /// Gets the message that was logged.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Gets the detailed description of the error if one is associated with this message; <c>null</c> if no error is
        /// associated with the message.
        /// </summary>
        public string? Error { get; }

        /// <inheritdoc />
        public override string ToString() => $"#{EntryNumber,5} {TimeStamp} [{Level,-11}] {Source}: {Message}";
    }
}