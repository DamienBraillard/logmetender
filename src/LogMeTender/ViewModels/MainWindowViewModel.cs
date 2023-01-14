using System.Collections.ObjectModel;
using System.Reactive;
using LogMeTender.Logging;
using LogMeTender.Views;
using ReactiveUI;

namespace LogMeTender.ViewModels
{
    /// <summary>
    /// A view-model that handles the main application window.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            OpenedSources = new ObservableCollection<LogSourceViewModel>();
            
            OpenedSources.Add(new LogSourceViewModel(new FakeLogSource("My fake log source", "FLS")));

            CloseSourceCommand = ReactiveCommand.Create<LogSourceViewModel>(s => OpenedSources.Remove(s));
        }

        /// <summary>
        /// Gets the list of opened log sources.
        /// </summary>
        public ObservableCollection<LogSourceViewModel> OpenedSources { get; }

        /// <summary>
        /// Gets the command that can be used to close a log source.
        /// </summary>
        public ReactiveCommand<LogSourceViewModel, Unit> CloseSourceCommand { get; }
    }

}