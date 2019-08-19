using BankOCR.Abstractions;
using System.IO;

namespace BankOCR.Console {
    /// <summary>
    /// Provides a more convenient entry point for the application.
    /// This class supports constructor dependency injection and
    /// offers a single <see cref="Run"/> method that's invoked
    /// with the parameters passed on the command line.
    /// </summary>
    class Application {
        private readonly IBankOcrScanner scanner;

        public Application(
            IBankOcrScanner scanner
        ) {
            this.scanner = scanner;
        }

        public void Run(FileInfo file) {
            using var reader = new StreamReader(file.OpenRead());

            var fileContents = reader.ReadToEnd();
            var lines = scanner.Scan(fileContents);

            foreach (var line in lines) {
                System.Console.WriteLine(line);
            }
        }
    }
}
