using System;
using System.Collections.Generic;

namespace LogMeTender.Logging
{
    /// <summary>
    /// A log event source that process messages from a given origin.
    /// </summary>
    public interface ILogSource : IAsyncEnumerable<LogReadEvent>
    {
        /// <summary>
        /// Gets the full name that uniquely identifies the log emitter or store 
        /// </summary>
        /// <remarks>The short name is used to identify the log source when space is unrestricted in the UI.</remarks>
        string Name { get; }
        
        /// <summary>
        /// Gets the short name that identifies the log emitter or store.
        /// </summary>
        /// <remarks>The short name is used to identify the log source when space is restricted in the UI.</remarks>
        string ShortName { get; }

        /// <summary>
        /// Occurs when the value of the <see cref="IsPaused"/> property changes.
        /// </summary>
        event EventHandler? IsPausedChanged;

        /// <summary>
        /// Occurs when the value of the <see cref="IsAlive"/> property changes.
        /// </summary>
        event EventHandler? IsAliveChanged;

        /// <summary>
        /// Gets or sets a value indicating whether the log source is currently paused and stops processing log event from the
        /// log emitter or store.
        /// </summary>
        bool IsPaused { get; set; }
        
        /// <summary>
        /// Gets a value indicating whether the log emitter or store this <see cref="ILogSource"/> is observing is alive. 
        /// </summary>
        /// <remarks>
        /// This property returns <c>false</c> if for example, the log source observes a file that does not exist anymore
        /// or if the log source observes a network source that has disconnected.
        /// </remarks>
        bool IsAlive { get; }
    }
}