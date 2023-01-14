using System;
using System.Collections.Generic;

namespace LogMeTender.Logging
{
    /// <summary>
    /// A data structure returned by <see cref="ILogReader.ReadLogEntries"/> when hte log source changes.
    /// </summary>
    public class LogReadEvent
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="LogReadEvent"/> class.
        /// </summary>
        /// <param name="reason">The <see cref="LogReadReason"/> that describes the reason this log event occurred.</param>
        /// <param name="entries">The collection of <see cref="LogEntry"/> that have been read from the log source.</param>
        /// <exception cref="ArgumentNullException"><paramref name="entries"/> is <c>null</c>.</exception>
        public LogReadEvent(LogReadReason reason, IReadOnlyCollection<LogEntry> entries)
        {
            Reason = reason;
            Entries = entries ?? throw new ArgumentNullException(nameof(entries));
        }

        /// <summary>
        /// Gets the <see cref="LogReadReason"/> that describes the reason this log event occurred.
        /// </summary>
        public LogReadReason Reason { get; }

        /// <summary>
        /// Gets the collection of <see cref="LogEntry"/> that have been read from the log source.
        /// </summary>
        /// <remarks>
        /// The collection contains only the new log events that have been read since the last event or the
        /// initial log events if the source has just been opened.
        /// </remarks>
        public IReadOnlyCollection<LogEntry> Entries { get; }
    }
}
