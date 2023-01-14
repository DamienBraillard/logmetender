using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using LogMeTender.ViewModels;
using ReactiveUI;

namespace LogMeTender.Views
{
    /// <summary>
    /// A view that renders the main application window.
    /// </summary>
    public class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            AvaloniaXamlLoader.Load(this);
            this.WhenActivated(d => { });

#if DEBUG
            this.AttachDevTools();
#endif
            
        }
    }
}