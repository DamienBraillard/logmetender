using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Avalonia.Threading;
using LogMeTender.ViewModels;
using ReactiveUI;

namespace LogMeTender.Views
{
    /// <summary>
    /// A view that represents a tab in the main window that displays a log source.
    /// </summary>
    public class LogSourceView : ReactiveUserControl<LogSourceViewModel>
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="LogSourceView"/> class.
        /// </summary>
        public LogSourceView()
        {
            AvaloniaXamlLoader.Load(this);
            this.WhenActivated(d => { });

            EnableSelectedItemAlwaysVisible();

        }

        /// <summary>
        /// Wires up events to ensure that the selected data grid item is always visible.
        /// </summary>
        private void EnableSelectedItemAlwaysVisible()
        {
            var logEntriesDataGrid = this.FindControl<DataGrid>("LogEntriesDataGrid") ?? throw new InvalidOperationException("Control not found: LogEntriesDataGrid");
            logEntriesDataGrid.SelectionChanged += (sender, args) =>
            {
                // We do this only if here is exactly one item selected
                if (logEntriesDataGrid.SelectedItems.Count == 1)
                {
                    var item = logEntriesDataGrid.SelectedItems[0];
                    Dispatcher.UIThread.Post(() =>
                    {
                        try
                        {
                            logEntriesDataGrid.ScrollIntoView(item, column: null);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }, DispatcherPriority.DataBind);
                }
            };
        }
    }
}