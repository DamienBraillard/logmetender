using System;
using System.Collections.ObjectModel;
using LogMeTender.Logging;
using ReactiveUI;
using System.Linq;
using System.Reactive.Disposables;
using DynamicData;

namespace LogMeTender.ViewModels
{
    /// <summary>
    /// A view-model that displays a log source.
    /// </summary>
    public class LogSourceViewModel : ViewModelBase
    {
        private readonly ILogSource _logSource;
        private LogEntry? _selectedLogEntry;

        /// <summary>
        /// Initialize a new instance of the <see cref="LogSourceViewModel"/> class.
        /// </summary>
        /// <param name="logSource">The <see cref="ILogSource"/> that provides the log entries to be displayed.</param>
        /// <exception cref="ArgumentNullException"><paramref name="logSource"/> is <c>null</c>.</exception>
        public LogSourceViewModel(ILogSource logSource)
        {
            _logSource = logSource ?? throw new ArgumentNullException(nameof(logSource));
            LogEntries = new ObservableCollection<LogEntry>();

            this.WhenActivated((disposables) =>
            {
                _logSource
                    .ToObservable()
                    .Subscribe(ProcessEvent)
                    .DisposeWith(disposables);
            });
        }

        private void ProcessEvent(LogReadEvent readEvent)
        {
            if (readEvent.Entries != null)
                LogEntries.AddRange(readEvent.Entries);
            SelectedLogEntry = LogEntries.LastOrDefault();
        }

        /// <summary>
        /// Gets a short name for the log source.
        /// </summary>
        public string ShortName => _logSource.ShortName;

        /// <summary>
        /// Gets the full name of the log source.
        /// </summary>
        public string Name => _logSource.Name;

        /// <summary>
        /// Gets the log entries to display in the tab;
        /// </summary>
        public ObservableCollection<LogEntry> LogEntries { get; }

        /// <summary>
        /// Gets or Sets the log entry that is currently selected.
        /// </summary>
        public LogEntry? SelectedLogEntry
        {
            get => _selectedLogEntry;
            set => this.RaiseAndSetIfChanged(ref _selectedLogEntry, value);
        }
    }
}