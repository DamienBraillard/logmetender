using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using ReactiveUI;

namespace LogMeTender.ViewModels
{
    /// <summary>
    /// A base class of all the view-models.
    /// </summary>
    public class ViewModelBase : ReactiveObject, IActivatableViewModel
    {
        /// <inheritdoc/>
        public ViewModelActivator Activator { get; } = new ViewModelActivator();
    }
}