using System;
using Avalonia.Markup.Xaml;

namespace LogMeTender.Extensions
{
    /// <summary>
    /// A markup extension that provides translations
    /// </summary>
    public class Translate : MarkupExtension
    {
        private readonly string _originalText;

        /// <summary>
        /// Initialize a new instance of the <see cref="Translate"/> class.
        /// </summary>
        /// <param name="originalText">The original text that must be translated.</param>
        public Translate(string originalText)
        {
            _originalText = originalText;
        }

        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
#warning TODO: This will have to be implemented once.
            return _originalText;
        }
    }
}