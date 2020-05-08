using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Media;
using LogMeTender.ViewModels;

namespace LogMeTender
{
    /// <summary>
    /// A "fall-back" data template that resolves the view-models to their views.
    /// </summary>
    /// <remarks>
    /// The view type name is inferred from the view-model type name by replacing "ViewModel" by "View" in the
    /// view-model type name.
    /// </remarks>
    public class ViewLocator : IDataTemplate
    {
        /// <inheritdoc/>
        public bool SupportsRecycling => false;

        /// <inheritdoc/>
        public IControl Build(object data)
        {
            try
            {
                if (data == null)
                    return new TextBlock();

                var name = data.GetType().FullName?.Replace("ViewModel", "View") ?? "";
                var type = Type.GetType(name, true)!;
                return (Control)Activator.CreateInstance(type)!;
            }
            catch (Exception exception)
            {
                return new TextBlock
                {
                    Text = $"Error locating view for view-model '{data?.GetType().FullName ?? "*null*"}: {exception.Message}",
                    Background = Brushes.Red,
                    Foreground = Brushes.Yellow,
                };
            }
        }

        /// <inheritdoc/>
        public bool Match(object data)
        {
            return data is ViewModelBase;
        }
    }
}