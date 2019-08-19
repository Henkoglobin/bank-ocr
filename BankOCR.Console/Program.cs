using Microsoft.Extensions.DependencyInjection;
using System.IO;
using BankOCR.Abstractions;

namespace BankOCR.Console {
    /// <summary>
    /// The main entry point for the application.
    /// This project uses the DragonFruit application model
    /// (https://github.com/dotnet/command-line-api/wiki/DragonFruit-overview)
    /// in order to provide a strongly-types main method.
    /// </summary>
    class Program {
        /// <summary>
        /// Parses a file that consists of 3x3 clusters of ASCII characters, where each one
        /// represents a digit. Digits are separated by spaces, while whole numbers are separated
        /// by whole lines.
        /// </summary>
        /// <param name="file"></param>
        static void Main(FileInfo file) {
            if (file == null) {
                System.Console.WriteLine($"--{nameof(file)} must be specified.");
                return;
            }

            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            serviceCollection.BuildServiceProvider()
                .GetRequiredService<Application>()
                .Run(file);
        }

        /// <summary>
        /// Configures all services used by the <see cref="Application"/>.
        /// </summary>
        /// <param name="serviceCollection">
        /// The <see cref="ServiceCollection"/> to register all services with.
        /// </param>
        private static void ConfigureServices(ServiceCollection serviceCollection)
            => serviceCollection
                .AddTransient<IDigitSeparator, DigitSeparator>()
                .AddTransient<IDigitScanner, DigitScanner>()
                .AddTransient<IBankOcrScanner, BankOcrScanner>()
                .AddSingleton<Application>();
    }
}
