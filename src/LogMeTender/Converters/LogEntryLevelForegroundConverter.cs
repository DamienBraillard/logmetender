using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;
using LogMeTender.Logging;

namespace LogMeTender.Converters
{
    /// <summary>
    /// A converter that converts a <see cref="LogEntryLevel"/> to a background <see cref="Brush"/>.
    /// </summary>
    /// <remarks>See https://github.com/AvaloniaUI/Avalonia/issues/2819</remarks>
    public class LogEntryLevelForegroundConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Brushes.Transparent;

            if (!(value is LogEntryLevel levelValue))
                throw new ArgumentException(
                    $"{nameof(value)} (of type {value.GetType().Name}) must be of type {nameof(LogEntryLevel)}.", nameof(value));

            return levelValue switch
            {
                LogEntryLevel.Trace => Brushes.Gray,
                LogEntryLevel.Debug => Brushes.DeepSkyBlue,
                LogEntryLevel.Information => Brushes.Green,
                LogEntryLevel.Warning => Brushes.Orange,
                LogEntryLevel.Error => Brushes.Red,
                LogEntryLevel.Fatal => Brushes.Magenta,
                _ => throw new ArgumentOutOfRangeException(nameof(value), $"Unsupported log level value ({levelValue}).")
            };
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException($"{GetType().Name} does not support converting back.");
        }
    }
}