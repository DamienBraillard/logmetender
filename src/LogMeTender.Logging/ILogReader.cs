using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace LogMeTender.Logging
{
    /// <summary>
    /// A reader that can read log files.
    /// </summary>
    public interface ILogReader
    {
        /// <summary>
        /// Reads all the <see cref="LogEntry"/> from the specified <paramref name="source"/> <see cref="Stream"/>.
        /// </summary>
        /// <param name="source">The <see cref="Stream"/> from which the log entries must be read (see remarks).</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that can stop the read operation.</param>
        /// <returns>
        /// An <see cref="IAsyncEnumerable{LogReadEvent}"/> that yields the <see cref="LogEntry"/> read
        /// from <paramref name="source"/>.
        /// </returns>
        /// <remarks>
        /// <para>Note to implementors:</para>
        /// <para>
        /// The method implementation should only read lot events sequentially until the end of the stream
        /// or until the <paramref name="cancellationToken"/> is cancelled.
        /// </para>
        /// <para>
        /// The passed <see cref="Stream"/> is not writable and not seekable. Synchronous reads are not
        /// also not supported and will yield to an error. 
        /// </para>
        /// </remarks>
        IAsyncEnumerable<LogEntry> ReadLogEntries(Stream source, CancellationToken cancellationToken);
    }
}
