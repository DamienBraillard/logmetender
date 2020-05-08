using Avalonia;
using Avalonia.Logging.Serilog;
using Avalonia.ReactiveUI;

namespace LogMeTender
{
    /// <summary>
    /// A class that exposes the main entry point of the application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point of the application.
        /// </summary>
        /// <param name="args">The command line arguments that were specified when the application was started.</param>
        /// <remarks>
        /// Initialization code. Don't use any Avalonia, third-party APIs or any
        /// SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        /// yet and stuff might break.
        /// </remarks>
        public static void Main(string[] args)
        {
            BuildAvaloniaApp()
                .StartWithClassicDesktopLifetime(args);
        }

        /// <summary>
        /// Builds the Avalonia application.
        /// </summary>
        /// <returns>A new <see cref="AppBuilder"/> that can be used to build the Avalonia application.</returns>
        /// <remarks>Don't remove, it is also used by visual designer.</remarks>
        public static AppBuilder BuildAvaloniaApp()
        {
            return AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToDebug()
                .UseReactiveUI();
        }
    }
}