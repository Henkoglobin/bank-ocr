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

        internal int Run(FileInfo fileInfo) {
            if (fileInfo == null) {
                RunImpl(System.Console.In);
            } else {
                using var reader = new StreamReader(fileInfo.OpenRead());
                RunImpl(reader);
            }
         
            return 0;
        }

        private void RunImpl(TextReader reader) {
            var input = reader.ReadToEnd();
            var lines = scanner.Scan(input);

            foreach (var line in lines) {
                System.Console.WriteLine(line);
            }

            reader.Dispose();
        }
    }
}
