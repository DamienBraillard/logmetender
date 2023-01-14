using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Nito.AsyncEx;

namespace LogMeTender.Logging
{
    /// <summary>
    /// A fake log source that emits events every second.
    /// </summary>
    public class FakeLogSource : ILogSource
    {
        private const int InitialLogsCount = 10_000;
        private readonly PauseTokenSource _pauseTokenSource;

        /// <summary>
        /// Initialize a new instance of the <see cref="FakeLogSource"/>
        /// </summary>
        /// <param name="name">The full name of the fake source.</param>
        /// <param name="shortName">The short name of the fake source.</param>
        public FakeLogSource(string name, string shortName)
        {
            Name = name;
            ShortName = shortName;
            _pauseTokenSource = new PauseTokenSource();
        }

        /// <inheritdoc />
        public string Name { get; }

        /// <inheritdoc />
        public string ShortName { get; }

        /// <inheritdoc />
        public event EventHandler? IsPausedChanged;

        /// <inheritdoc />
        public event EventHandler? IsAliveChanged
        {
            add {}
            remove {}
        }

        /// <inheritdoc />
        public bool IsPaused
        {
            get => _pauseTokenSource.IsPaused;
            set
            {
                if (value != _pauseTokenSource.IsPaused)
                {
                    _pauseTokenSource.IsPaused = value;
                    IsPausedChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <inheritdoc />
        public bool IsAlive { get; } = true;

        /// <inheritdoc />
        public async IAsyncEnumerator<LogReadEvent> GetAsyncEnumerator(CancellationToken cancellationToken = new CancellationToken())
        {
            var logLevels = Enum.GetValues(typeof(LogEntryLevel)).Cast<LogEntryLevel>().OrderBy(l => l).ToArray();

            LogEntry NextEntry(int entryNumber)
            {
                var level = logLevels[entryNumber % logLevels.Length];
                var error = (level == LogEntryLevel.Error || level == LogEntryLevel.Fatal)
                    ? null
                    : "This is a sample error message #{counter}";
                var message = $"This is a sample {level} message #{entryNumber}";

                return new LogEntry(entryNumber, DateTime.Now, level, Name, message, error);
            }

            // Initial logs
            var initialLogs = await Task.Run(
                () => Enumerable.Range(start: 0, count: InitialLogsCount).Select(NextEntry).ToImmutableList(),
                cancellationToken);

            yield return new LogReadEvent(LogReadReason.LogOpened, initialLogs);

            var counter = InitialLogsCount;
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(1000), cancellationToken);

                counter++;
                var reason = (counter % 60 == 0) ? LogReadReason.LogSourceReset : LogReadReason.NewLogEvents;
                var entry = NextEntry(counter);
                Console.WriteLine($"Emitting log event {entry}");
                yield return new LogReadEvent(reason, new[] { entry });
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }
}